using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>();
            //services.AddTransient<IFatigueEntryOperations, FatigueEntryOperations>();
            //services.AddTransient<IFatigueResultOperations, FatigueResultOperations>();
            //services.AddTransient<ITrainingOperations, TrainingOperations>();
            //services.AddTransient<IExerciseOperations, ExerciseOperations>();
            //services.AddTransient<IExerciseTypeOperations, ExerciseTypeOperations>();
            //services.AddTransient<ILiftOperations, LiftOperations>();
            //services.AddTransient<IApplicationUserOperations, ApplicationUserOperations>();
            //services.AddTransient<IArticleOperations, ArticleOperations>();
            //services.AddTransient<IBodyweightOperations, BodyweightOperations>();
            //services.AddTransient<IReportOperations, ReportOperations>();
            //services.AddTransient<IExcelOperations, ExcelOperations>();

            return services;
        }
    }
}
