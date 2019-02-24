using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ServiceLayer
{
    public class ServiceAutomapper
    {
        public static void Configure()
        {
            Mapper.Initialize(x => { x.AddProfile<ModelsToDtos>(); });
        }
    }

    public class ModelsToDtos : Profile
    {
        public ModelsToDtos()
        {
            //CreateMap<FatigueEntry, FatigueEntryDto>();
            //CreateMap<FatigueEntryDto, FatigueEntry>()
            //    .IgnoreAllVirtual()
            //    .ForMember(x => x.Id, opt => opt.Ignore());

            //CreateMap<FatigueResult, FatigueResultDto>();
            //CreateMap<FatigueResultDto, FatigueResult>()
            //    .IgnoreAllVirtual()
            //    .ForMember(x => x.Id, opt => opt.Ignore());

            //CreateMap<Training, TrainingDto>();
            //CreateMap<TrainingDto, Training>()
            //    .IgnoreAllVirtual()
            //    .ForMember(x => x.Id, opt => opt.Ignore());

            //CreateMap<Exercise, ExerciseDto>();
            //CreateMap<ExerciseDto, Exercise>()
            //    .ForMember(x => x.Id, opt => opt.Ignore());

            //CreateMap<ExerciseType, ExerciseTypeDto>();
            //CreateMap<ExerciseTypeDto, ExerciseType>()
            //    .IgnoreAllVirtual()
            //    .ForMember(x => x.Id, opt => opt.Ignore());

            //CreateMap<AthleteMax, AthleteMaxDto>();
            //CreateMap<AthleteMaxDto, AthleteMax>()
            //    .IgnoreAllVirtual();

            //CreateMap<Article, ArticleDto>();
            //CreateMap<ArticleDto, Article>()
            //    .IgnoreAllVirtual();

            //CreateMap<Bodyweight, BodyweightDto>();
            //CreateMap<BodyweightDto, Bodyweight>()
            //    .IgnoreAllVirtual();

            //CreateMap<Report, ReportDto>();
            //CreateMap<ReportDto, Report>()
            //    .IgnoreAllVirtual();

            //CreateMap<ReportData, ReportDataDto>();
            //CreateMap<ReportDataDto, ReportData>()
            //    .IgnoreAllVirtual();

            //CreateMap<ApplicationUser, RegisterViewModel>()
            //    .ForAllOtherMembers(opts => opts.Ignore());
            //CreateMap<RegisterViewModel, ApplicationUser>()
            //    .ForAllOtherMembers(opts => opts.Ignore());

            //CreateMap<ExerciseViewModel, ExerciseDto>();
            //CreateMap<ExerciseDto, ExerciseViewModel>()
            //    .ForMember(x => x.Order, opt => opt.Ignore());
        }

    }
}
