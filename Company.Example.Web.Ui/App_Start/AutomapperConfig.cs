using AutoMapper;
using Company.Example.Core.Domain.Entities;
using Company.Example.Web.Ui.Models.InputModels;
using Company.Example.Web.Ui.Models.ViewModels;

namespace Company.Example.Web.Ui
{
	public class AutomapperConfig
	{
		public static void RegisterMapping()
		{
			Mapper.CreateMap<Project, ProjectViewModel>();
			Mapper.CreateMap<ProjectInputModel, Project>();


			Mapper.CreateMap<Project, ProjectInputModel>().
				ForMember(dest => dest.DateOfCreation,
						  opt => opt.ResolveUsing(src => src.DateOfCreation != null ? src.DateOfCreation.ToString() : "Uncreated")).
				ForMember(dest => dest.StartDate,
						  opt => opt.ResolveUsing(src => src.StartDate != null ? src.StartDate.Value.ToShortDateString() : "NoStartDate")).
				ForMember(dest => dest.IsClosed,
						  opt => opt.ResolveUsing(src => src.IsClosed ? "Closed" : "Open"));
		}
	}
}