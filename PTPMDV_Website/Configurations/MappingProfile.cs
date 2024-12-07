﻿using AutoMapper;
using PTPMDV_Website.Models;
using PTPMDV_Website.ViewModels;
using System;


namespace PTPMDV_Website.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MotoBike, MotoVM>();

            CreateMap<MotoVM, MotoBike>();

            CreateMap<MotoVersion, VersionVM>()
                .ForMember(dest => dest.VersionColorVM, opt => opt.MapFrom(src => src.VersionColors));

            CreateMap<VersionColor, VersionColorVM>()
                .ForMember(dest => dest.VersionImageVM, opt => opt.MapFrom(src => src.VersionImages));

            CreateMap<VersionImage, VersionImageVM>();

            CreateMap<MotoLibrary, LibraryVM>()
                .ForMember(dest => dest.LibraryImageVM, opt => opt.MapFrom(src => src.LibraryImages));

            CreateMap<LibraryImage, LibraryImageVM>();

            CreateMap<VersionVM, MotoVersion>()
                .ForMember(dest => dest.VersionColors, opt => opt.MapFrom(src => src.VersionColorVM));

            CreateMap<VersionColorVM, VersionColor>()
                .ForMember(dest => dest.VersionImages, opt => opt.MapFrom(src => src.VersionImageVM));

            CreateMap<VersionImageVM, VersionImage>();

            CreateMap<LibraryVM, MotoLibrary>()
                .ForMember(dest => dest.LibraryImages, opt => opt.MapFrom(src => src.LibraryImageVM));

            CreateMap<LibraryImageVM, LibraryImage>();

            CreateMap<BrandVM, Brand>()
                .ForMember(dest => dest.MaHangSanXuat, opt => opt.MapFrom(src => src.MaHangSanXuat))
                .ForMember(dest => dest.TenHangSanXuat, opt => opt.MapFrom(src => src.TenHangSanXuat))
                .ForMember(dest => dest.QuocGia, opt => opt.MapFrom(src => src.QuocGia))
                .ForMember(dest => dest.MoTaNgan, opt => opt.MapFrom(src => src.MoTaNgan));

            // Cấu hình ánh xạ giữa Brand và BrandVM
            CreateMap<Brand, BrandVM>()
                .ForMember(dest => dest.MaHangSanXuat, opt => opt.MapFrom(src => src.MaHangSanXuat))
                .ForMember(dest => dest.TenHangSanXuat, opt => opt.MapFrom(src => src.TenHangSanXuat))
                .ForMember(dest => dest.QuocGia, opt => opt.MapFrom(src => src.QuocGia))
                .ForMember(dest => dest.MoTaNgan, opt => opt.MapFrom(src => src.MoTaNgan));

            CreateMap<TypeVM, MotoType>()
                .ForMember(dest => dest.MaLoai, opt => opt.MapFrom(src => src.MaLoai))
                .ForMember(dest => dest.TenLoai, opt => opt.MapFrom(src => src.TenLoai))
                .ForMember(dest => dest.DoiTuongSuDung, opt => opt.MapFrom(src => src.DoiTuongSuDung))
                .ForMember(dest => dest.MoTaNgan, opt => opt.MapFrom(src => src.MoTaNgan));
            // Cấu hình ánh xạ giữa MotoType và MotoTypeVM
            CreateMap<MotoType, TypeVM>()
                .ForMember(dest => dest.MaLoai, opt => opt.MapFrom(src => src.MaLoai))
                .ForMember(dest => dest.TenLoai, opt => opt.MapFrom(src => src.TenLoai))
                .ForMember(dest => dest.DoiTuongSuDung, opt => opt.MapFrom(src => src.DoiTuongSuDung))
                .ForMember(dest => dest.MoTaNgan, opt => opt.MapFrom(src => src.MoTaNgan));
        }
    }
}
