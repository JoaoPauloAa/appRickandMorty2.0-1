using ApiRickandMorty2._0.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRickandMorty2._0.Models
{
    public class CharacterDAO
    {
        private Database db;
        public void Insert(Character character)
        {
            var strQuery = "";
            strQuery += "insert into Personagem(nomePersonagem,statusPersonagem,especie,genero,localizacao) values";
            strQuery += string.Format("('{0}','{1}','{2}','{3}','{4}')", character.name, character.status, character.species, character.gender, character.location);


            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Update(Character character)
        {
            var strQuery = "";
            strQuery += "update Personagem set ";
            strQuery += string.Format("nomePersonagem='{0}',statusPersonagem='{1}',especie='{2}',genero='{3}',localizacao='{4}' where idPersonagem='{5}'", character.name, character.status, character.species, character.gender, character.location, character.id);


            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Delete(int id)
        {
            var strQuery = "";
            strQuery += string.Format(" delete from  Personagem where idPersonagem = '{0}';", id);

            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Character> SelectTodosCharacters()
        {
            using (db = new Database())
            {
                string strQuery = "select * from Personagem;";
                var leitor = db.RetornaComando(strQuery);

                return GeraListCharacter(leitor);
            }
        }

        public Character SelectCharacterPeloId(int id)
        {
            using (db = new Database())
            {
                string strQuery = string.Format("select * from Personagem WHERE idPersonagem = '{0}';", id);
                var leitor = db.RetornaComando(strQuery);

                return GeraListCharacter(leitor).FirstOrDefault();
            }
        }

        public List<Character> GeraListCharacter(MySqlDataReader leitor)
        {
            var characters = new List<Character>();
    
            while (leitor.Read())
            {
                var tempCharacter = new Character()
                {
                    id = int.Parse(leitor["idPersonagem"].ToString()),
                    name = leitor["nomePersonagem"].ToString(),
                    status = leitor["statusPersonagem"].ToString(),
                    species = leitor["especie"].ToString(),
                    gender = leitor["genero"].ToString(),
                    location = int.Parse(leitor["localizacao"].ToString())

                };
                characters.Add(tempCharacter);
            }
            leitor.Close();
            return characters;
        }
    }
}