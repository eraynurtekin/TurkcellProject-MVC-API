using Microsoft.AspNetCore.Mvc;
using System;

namespace FastShop.API.Filters
{
    public class IsExistAttribute : TypeFilterAttribute
    {
        public IsExistAttribute() : base(typeof(CheckExistingProducts))
        {

        }
    }
}
