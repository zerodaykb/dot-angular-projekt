﻿// <auto-generated />
using System;
using MassReconApi.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MassReconApi.Infrastucture.Migrations
{
    [DbContext(typeof(MassReconContext))]
    partial class MassReconContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("MassReconApi.Infrastucture.Model.ReconNote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<DateTime>("DateOfUpdate");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("ReconNote");
                });

            modelBuilder.Entity("MassReconApi.Infrastucture.Model.Report", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<DateTime>("DateOfUpdate");

                    b.Property<string>("Notes");

                    b.Property<int>("Quantity");

                    b.Property<string>("SearchPhrase");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("MassReconApi.Infrastucture.Model.ReportItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateOfCreation");

                    b.Property<DateTime>("DateOfUpdate");

                    b.Property<string>("Ip");

                    b.Property<bool>("IsChecked");

                    b.Property<string>("Notes");

                    b.Property<long?>("ReportId");

                    b.Property<string>("SourceType");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportItem");
                });

            modelBuilder.Entity("MassReconApi.Infrastucture.Model.ReportItem", b =>
                {
                    b.HasOne("MassReconApi.Infrastucture.Model.Report", "Report")
                        .WithMany("ReportItems")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
