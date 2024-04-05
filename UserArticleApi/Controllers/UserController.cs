using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserArticleApi.Models;
using UserArticleApi.Services;

namespace UserArticleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]

        public IActionResult GetAll()
        {

            var GetUserAll = _userServices.GetUsers();
            if (GetUserAll == null || !GetUserAll.Any())
            {
                return NotFound(); // Aucun Utilisateur trouvé, renvoyer une réponse 404
            }
            return Ok(GetUserAll);
        }

        [HttpGet("{id}")]

        public IActionResult GetId(int id) {

            // verifier si Id est valide
            if (id <= 0) {
                return BadRequest("L'ID fourni n'est pas valide.");
            }
            // recuperer l utilisateur par son Id
            var GetUserById = _userServices.GetById(id);

            //si l utilisateur n existe pas il me sort l erreur 404
            //en affichant qu aucun utilisateur touver avec son id 
            //specifier
            if (GetUserById is null)
            {
                return NotFound("Aucun Utilisateur trouver avec son id specifique");
            }
            return Ok(GetUserById);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Validation de l'identifiant de la ressource
            if (id <= 0)
            {
                return BadRequest("L'ID fourni n'est pas valide.");
            }

            // Vérification de la présence de la ressource
            var existingUser = _userServices.GetById(id);
            if (existingUser == null)
            {
                return NotFound("Aucun utilisateur trouvé avec l'ID spécifié.");
            }



            // Supprimer la ressource
            try
            {
                _userServices.Delete(id);
                return NoContent(); // Renvoyer une réponse 204 No Content si la suppression réussit
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la suppression de l'utilisateur : {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] User newUser)
        {
            // Validation des d onnées entrantes
            if (!ModelState.IsValid)
            {
                // Si les données ne sont pas valides, renvoyer une réponse BadRequest avec les erreurs de validation
                return BadRequest(ModelState);
            }

            try
            {
                // Vérifier si l'utilisateur existe déjà dans la base de données
                var existingUser = _userServices.GetById(newUser.Id);
                if (existingUser != null)
                {
                    // Si l'utilisateur existe déjà, renvoyer une réponse Conflict avec un message approprié
                    return Conflict("Un utilisateur avec ce nom d'utilisateur existe déjà.");
                }

                // Si l'utilisateur n'existe pas, ajouter l'utilisateur à la base de données
                _userServices.Create(newUser);

                // Retourner une réponse 201 Created avec l'utilisateur créé dans le corps de la réponse
                // et inclure également l'URL de localisation de la ressource nouvellement créée dans l'en-tête de réponse
             return    CreatedAtAction(nameof(GetId), new { id = newUser.Id },newUser);
            }
            catch (Exception ex)
            {
                // En cas d'erreur inattendue, renvoyer une réponse 500 Internal Server Error avec un message d'erreur
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'utilisateur : {ex.Message}");
            }
        }

        [HttpPut]

        public IActionResult UpdateUser( int id,User user)
        {
          // verifie si Id fournie par l utilisateur est valide
          if(id <= 0)
            {
                BadRequest("L Id fournie pas l utilisateur n est pas valide");
            }
            // Recuperer l utilisateur dans la base de donner 
            var existingUser = _userServices.GetById(id);
            //Si l utilisateur n existe pas il me renvoie l 
            //erreur 404 aucun utilisateur trouver avec l Id specifier
            if(existingUser is null)
            {
                NotFound("Aucun utilisateur trouver avec l Id specifier");
            }

            // mettre a jours les donners de l utilisateur avec les 
            //nouvelles donnees

            existingUser.Id = user.Id;
            existingUser.Email = user.Email;
            existingUser.Name = user.Email;
            // mettre a jours les donnnes dans la base de donnees

            _userServices.Update(user);

            //retourne une reponse que la mise a jours a reussie
            return Ok("L'utilisateur a été mis à jour avec succès.");
            
        }

    }
}
