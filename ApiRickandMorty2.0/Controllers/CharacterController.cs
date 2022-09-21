using ApiRickandMorty2._0.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRickandMorty2._0.Controllers
{
    public class CharacterController : ApiController
    {
        // GET: api/Character
        [HttpGet]
        public IEnumerable Get()
        {
            var characterDAO = new CharacterDAO();
            var characterlist = characterDAO.SelectTodosCharacters();
            return characterlist;
        }


        // GET: api/Character/5
        [HttpGet]
        public Character Get(int id)
        {
            var characterDAO = new CharacterDAO();
            var character = characterDAO.SelectCharacterPeloId(id);
            return character;
        }

        // POST: api/Character
        [HttpPost]
        public void Post([FromBody] Character character)
        {
            if (character == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var characterDAO = new CharacterDAO();
            characterDAO.Insert(character);
        }

        // PUT: api/Character/5
        public void Put(int id, [FromBody] Character character)
        {
            if (character == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            var characterDAO = new CharacterDAO();
            characterDAO.Update(character);
        }

        // DELETE: api/Character/5
        public Character Delete(int id)
        {
            var characterDAO = new CharacterDAO();
            var character = characterDAO.SelectCharacterPeloId(id);
            if (character == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            characterDAO.Delete(id);
            return character;
        }
    }
}
