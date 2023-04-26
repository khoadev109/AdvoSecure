using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddMatterTaskTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatterTypeId",
                table: "Contacts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BillingGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    LastRun = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NextRun = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    BillToContactId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingGroup_Contacts_BillToContactId",
                        column: x => x.BillToContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourtGeographicalJurisdiction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtGeographicalJurisdiction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourtSittingInCity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtSittingInCity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatterArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaGroup = table.Column<int>(type: "integer", nullable: false),
                    AreaCode = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatterType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdInt = table.Column<long>(type: "bigint", nullable: false),
                    MatterNumber = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Synopsis = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CaseNumber = table.Column<string>(type: "text", nullable: false),
                    BillToContactDisplayName = table.Column<string>(type: "text", nullable: false),
                    MinimumCharge = table.Column<decimal>(type: "numeric", nullable: true),
                    EstimatedCharge = table.Column<decimal>(type: "numeric", nullable: true),
                    MaximumCharge = table.Column<decimal>(type: "numeric", nullable: true),
                    OverrideMatterRateWithEmployeeRate = table.Column<bool>(type: "boolean", nullable: false),
                    AttorneyForPartyTitle = table.Column<string>(type: "text", nullable: false),
                    CaptionPlaintiffOrSubjectShort = table.Column<string>(type: "text", nullable: false),
                    CaptionPlaintiffOrSubjectRegular = table.Column<string>(type: "text", nullable: false),
                    CaptionPlaintiffOrSubjectLong = table.Column<string>(type: "text", nullable: false),
                    CaptionOtherPartyShort = table.Column<string>(type: "text", nullable: false),
                    CaptionOtherPartyRegular = table.Column<string>(type: "text", nullable: false),
                    CaptionOtherPartyLong = table.Column<string>(type: "text", nullable: false),
                    MatterTypeId = table.Column<int>(type: "integer", nullable: true),
                    BillingGroupId = table.Column<int>(type: "integer", nullable: true),
                    BillToContactId = table.Column<int>(type: "integer", nullable: true),
                    DefaultBillingRateId = table.Column<int>(type: "integer", nullable: true),
                    MatterAreaId = table.Column<int>(type: "integer", nullable: true),
                    CourtGeographicalJurisdictionId = table.Column<int>(type: "integer", nullable: true),
                    CourtSittingInCityId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matter_BillingGroup_BillingGroupId",
                        column: x => x.BillingGroupId,
                        principalTable: "BillingGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matter_BillingRates_DefaultBillingRateId",
                        column: x => x.DefaultBillingRateId,
                        principalTable: "BillingRates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matter_Contacts_BillToContactId",
                        column: x => x.BillToContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matter_CourtGeographicalJurisdiction_CourtGeographicalJuris~",
                        column: x => x.CourtGeographicalJurisdictionId,
                        principalTable: "CourtGeographicalJurisdiction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matter_CourtSittingInCity_CourtSittingInCityId",
                        column: x => x.CourtSittingInCityId,
                        principalTable: "CourtSittingInCity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matter_MatterArea_MatterAreaId",
                        column: x => x.MatterAreaId,
                        principalTable: "MatterArea",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matter_MatterType_MatterTypeId",
                        column: x => x.MatterTypeId,
                        principalTable: "MatterType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProjectedStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProjectedEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsGroupingTask = table.Column<bool>(type: "boolean", nullable: false),
                    SequentialPredecessorId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CompletePercentage = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    TaskTypeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_TaskType_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Task_Task_SequentialPredecessorId",
                        column: x => x.SequentialPredecessorId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatterContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsClient = table.Column<bool>(type: "boolean", nullable: false),
                    IsClientContact = table.Column<bool>(type: "boolean", nullable: false),
                    IsAppointed = table.Column<bool>(type: "boolean", nullable: false),
                    IsParty = table.Column<bool>(type: "boolean", nullable: false),
                    PartyTitle = table.Column<string>(type: "text", nullable: false),
                    IsJudge = table.Column<bool>(type: "boolean", nullable: false),
                    IsWitness = table.Column<bool>(type: "boolean", nullable: false),
                    IsLeadAttorney = table.Column<bool>(type: "boolean", nullable: false),
                    IsAttorney = table.Column<bool>(type: "boolean", nullable: false),
                    IsSupportStaff = table.Column<bool>(type: "boolean", nullable: false),
                    IsThirdPartyPayor = table.Column<bool>(type: "boolean", nullable: false),
                    MatterId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatterContact_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatterContact_Matter_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskAssignedContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    AssignmentType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignedContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAssignedContact_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAssignedContact_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskMatter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    MatterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMatter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskMatter_Matter_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskMatter_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MatterTypeId",
                table: "Contacts",
                column: "MatterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingGroup_BillToContactId",
                table: "BillingGroup",
                column: "BillToContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Matter_BillingGroupId",
                table: "Matter",
                column: "BillingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Matter_BillToContactId",
                table: "Matter",
                column: "BillToContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Matter_CourtGeographicalJurisdictionId",
                table: "Matter",
                column: "CourtGeographicalJurisdictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Matter_CourtSittingInCityId",
                table: "Matter",
                column: "CourtSittingInCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Matter_DefaultBillingRateId",
                table: "Matter",
                column: "DefaultBillingRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Matter_MatterAreaId",
                table: "Matter",
                column: "MatterAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Matter_MatterTypeId",
                table: "Matter",
                column: "MatterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterContact_ContactId",
                table: "MatterContact",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterContact_MatterId",
                table: "MatterContact",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_SequentialPredecessorId",
                table: "Task",
                column: "SequentialPredecessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskTypeId",
                table: "Task",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignedContact_ContactId",
                table: "TaskAssignedContact",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignedContact_TaskId",
                table: "TaskAssignedContact",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMatter_MatterId",
                table: "TaskMatter",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMatter_TaskId",
                table: "TaskMatter",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MatterType_MatterTypeId",
                table: "Contacts",
                column: "MatterTypeId",
                principalTable: "MatterType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MatterType_MatterTypeId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "MatterContact");

            migrationBuilder.DropTable(
                name: "TaskAssignedContact");

            migrationBuilder.DropTable(
                name: "TaskMatter");

            migrationBuilder.DropTable(
                name: "Matter");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "BillingGroup");

            migrationBuilder.DropTable(
                name: "CourtGeographicalJurisdiction");

            migrationBuilder.DropTable(
                name: "CourtSittingInCity");

            migrationBuilder.DropTable(
                name: "MatterArea");

            migrationBuilder.DropTable(
                name: "MatterType");

            migrationBuilder.DropTable(
                name: "TaskType");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_MatterTypeId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "MatterTypeId",
                table: "Contacts");
        }
    }
}
