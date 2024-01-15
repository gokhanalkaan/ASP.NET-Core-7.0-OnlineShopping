using BusinessLayer.Abstract;
using DTOLayer;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _UserInfoComponent:ViewComponent
    {
        private readonly IAppUserService _userService;

        public _UserInfoComponent(IAppUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var user = _userService.TGetByID(id);

            return View(new UserInfoDto() {   UserId=user.Id, Name=user.Name, Surname=user.Surname});
        }
    }
}
