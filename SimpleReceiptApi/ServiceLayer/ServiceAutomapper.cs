using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DatabaseLayer.Models;
using ServiceLayer.DTOs;
using ServiceLayer.Extensions;
using ReceiptPriceTableQuery = DatabaseLayer.Models.ReceiptPriceTableQuery;

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
            CreateMap<Cafe, CafeDto>();
            CreateMap<CafeDto, Cafe>()
                .IgnoreAllVirtual()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>()
                .IgnoreAllVirtual()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<PriceTable, PriceTableDto>();
            CreateMap<PriceTableDto, PriceTable>()
                .IgnoreAllVirtual()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<PriceTableQuery, PriceTableQueryDto>();
            CreateMap<PriceTableQueryDto, PriceTableQuery>()
                .IgnoreAllVirtual()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .IgnoreAllVirtual()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Receipt, ReceiptDto>();
            CreateMap<ReceiptDto, Receipt>()
                .IgnoreAllVirtual()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<ReceiptPriceTableQuery, ReceiptPriceTableQueryDto>();
            CreateMap<ReceiptPriceTableQueryDto, ReceiptPriceTableQuery>()
                .IgnoreAllVirtual()
                .ForMember(x => x.ReceiptId, opt => opt.Ignore())
                .ForMember(x => x.PriceTableQueryId, opt => opt.Ignore());

            CreateMap<WaiterCafe, WaiterCafeDto>();
            CreateMap<WaiterCafeDto, WaiterCafe>()
                .IgnoreAllVirtual()
                .ForMember(x => x.WaiterId, opt => opt.Ignore())
                .ForMember(x => x.CafeId, opt => opt.Ignore());

            CreateMap<Table, TableDto>();
            CreateMap<TableDto, Table>()
                .IgnoreAllVirtual()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
