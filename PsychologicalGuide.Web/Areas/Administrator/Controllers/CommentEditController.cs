namespace PsychologicalGuide.Web.Areas.Administrator.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using Data.Services;
    using Areas.Administrator.Models.Comment;
    using Infrastructure.Mapping;
    

    public class CommentEditController : AdminBaseController
    {
        private ICommentService commentService;

        public CommentEditController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public ActionResult Index()
        {
            var articles = this.commentService.All().To<CommentListItemViewModel>().ToList();

            return View(articles);
        }

        public ActionResult Edit(int id)
        {
            EditCommentViewModel model = this.Mapper.Map<EditCommentViewModel>(this.commentService.GetById(id));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCommentViewModel model)
        {
            this.commentService.Edit(model.Id, model.Content);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.commentService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}