using AutoMapper;
using FastShop.Dtos.Requests;
using FastShop.Dtos.Responses;
using FastShop.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Business.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductListResponse>();
            CreateMap<Category, CategoryListResponse>();
            CreateMap<AddProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<User, UserListResponse>();
            CreateMap<AddUserRequest, User>();
            CreateMap<Comment, CommentListResponse>();  
            CreateMap<AddCommentRequest, Comment>();
        }
        
        
    }
}
