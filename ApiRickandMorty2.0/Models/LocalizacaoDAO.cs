using ApiRickandMorty2._0.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRickandMorty2._0.Models
{
    public class LocalizacaoDAO
    {
        private Database db;
        public void Insert(Localizacao localizacao)
        {
            var strQuery = "";
            strQuery += "insert into Localizacao(nomeLocal,dimensao) values";
            strQuery += string.Format("('{0}','{1}')", localizacao.nomeLocal, localizacao.dimensao);


            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Update(Localizacao localizacao)
        {
            var strQuery = "";
            strQuery += "update Localizacao set ";
            strQuery += string.Format("nomeLocal='{0}',dimensao='{1}' where idLocal='{2}'", localizacao.nomeLocal, localizacao.dimensao, localizacao.idLocal);


            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }
        public void Delete(int id)
        {
            var strQuery = "";
            strQuery += string.Format(" delete from  Localizacao where idLocal = '{0}';", id);

            using (db = new Database())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Localizacao> SelectTodosLocalizacaos()
        {
            using (db = new Database())
            {
                string strQuery = "select * from Localizacao;";
                var leitor = db.RetornaComando(strQuery);

                return GeraListLocalizacao(leitor);
            }
        }

        public Localizacao SelectLocalizacaoPeloId(int id)
        {
            using (db = new Database())
            {
                string strQuery = string.Format("select * from Localizacao WHERE idLocal = '{0}';", id);
                var leitor = db.RetornaComando(strQuery);

                return GeraListLocalizacao(leitor).FirstOrDefault();
            }
        }

        public List<Localizacao> GeraListLocalizacao(MySqlDataReader leitor)
        {
            var localizacaos = new List<Localizacao>();

            while (leitor.Read())
            {
                var tempLocalizacao = new Localizacao()
                {
                    idLocal = int.Parse(leitor["idLocal"].ToString()),
                    nomeLocal = leitor["nomeLocal"].ToString(),
                    dimensao = leitor["dimensao"].ToString(),
                };
                localizacaos.Add(tempLocalizacao);
            }
            leitor.Close();
            return localizacaos;
        }
    }
}
