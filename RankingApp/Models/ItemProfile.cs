using AutoMapper;

namespace RankingApp.Models
{
    public class ItemProfile : Profile
    {

        public ItemProfile()
        {
            CreateMap<ItemModel, ItemModelDTO>();
        }
    }
}
