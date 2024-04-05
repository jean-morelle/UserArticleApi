using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UserArticleApi.DTO;
using UserArticleApi.Models;
using UserArticleApi.Services;

namespace UserArticleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleServices _articleServices;
        private readonly IMapper mapper;

        public ArticleController( IArticleServices articleServices,IMapper mapper)
        {
            _articleServices = articleServices;
            this.mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAll() {

            var GetArticleAll = _articleServices.GetArticles();

            if(GetArticleAll == null || !GetArticleAll.Any()) { 
            
            return NotFound(); //Aucunes  Article trouvé, renvoyer une réponse 404
            }
            return Ok(GetArticleAll);//Renvoyer les articles  avec le code de statut 200 OK
        }

        [HttpGet("{id}")]

        public IActionResult GetArticleById(int id) {

            //verifie si Id est valide 
            if (id <= 0)
            {
                return BadRequest("l Id fournie est invalide");
            }
            // recuperer la ressource par son Id
            var GetArticleId =_articleServices.GetArticleById(id);
            // verifie si la ressource existe
            if(GetArticleId == null)
            {
              return NotFound ("Aucun ARticle trouvé avec l'ID spécifié.");
            }

            return Ok(GetArticleId);
        }
        [HttpDelete]

        public IActionResult DeleteArticle(int id,Article article)
        {
            if (id <= 0)
            {
                return BadRequest("L Id fournie n est pas valide");

            }
            //  recuper l id dans la base de donner
            var Existing = _articleServices.GetArticleById(id);
            if (Existing is null)
            {
                NotFound("L article fournie par son id n existe pas dans la base de donnee");
            }

            try
            {
                _articleServices.Delete(id);
                return NoContent();// Renvoyer une réponse 204 No Content si la suppression réussit
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur s'est produite lors de la suppression de l'utilisateur : {ex.Message}");
            }
        }
        [HttpPatch]

        public IActionResult UpdateArticle(int id, Article article)
        {
            var articleModel = mapper.Map<Article>(article);
            if (id <= 0)
            {
                return BadRequest("L Id fournie est invalide");
            }
            // recuperer l ID de l article
            var GetArtricle = _articleServices.GetArticleById(id);
            //Verifier si l article existe dans la base de donnee
            if (GetArtricle is null)
            {
                NotFound("Aucune Articles trouver avec l Id specifier");
            }
            // mettons a jours les donnes de les articles  avec les nouvelles donnes

            GetArtricle.Title = articleModel.Title;
            GetArtricle.Content = articleModel.Content;
            GetArtricle.Id = articleModel.Id;
            GetArtricle.UserId = articleModel.UserId;
            GetArtricle.user = articleModel.user;
            // mettre a jours les donnnes dans la base de donnees
            _articleServices.Update(articleModel);
            //retourne une reponse que la mise a jours a reussie
            return Ok("L'article a été mis à jour avec succès.");
        }
        [HttpPost]
        public IActionResult Create([FromBody] ArticleCreateDto newArticle)
        {
            var articleModel = mapper.Map<Article>(newArticle);
            // Validation des d onnées entrantes
            if (!ModelState.IsValid)
            {
                // Si les données ne sont pas valides, renvoyer une réponse BadRequest avec les erreurs de validation
                return BadRequest(ModelState);
            }

            try
            {
                // Vérifier si l'article existe déjà dans la base de données
                var existingArticle = _articleServices.GetArticleById(articleModel.Id);
                if (existingArticle!= null)
                {
                    // Si l'article existe déjà, renvoyer une réponse Conflict avec un message approprié
                    return Conflict("Un article avec ce nom  existe déjà.");
                }

                // Si l article n'existe pas, ajouter l'article à la base de données
              _articleServices.Create(articleModel);

                // Retourner une réponse 201 Created avec l'article créé dans le corps de la réponse
                // et inclure également l'URL de localisation de la ressource nouvellement créée dans l'en-tête de réponse
                return CreatedAtAction(nameof(GetAll), new { id = articleModel.Id }, articleModel);
            }
            catch (Exception ex)
            {
                // En cas d'erreur inattendue, renvoyer une réponse 500 Internal Server Error avec un message d'erreur
                return StatusCode(500, $"Une erreur s'est produite lors de la création de l'utilisateur : {ex.Message}");
            }
        }

    }
}
