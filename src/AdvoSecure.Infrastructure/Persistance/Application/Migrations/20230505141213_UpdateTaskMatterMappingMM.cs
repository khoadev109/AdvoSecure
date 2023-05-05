using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaskMatterMappingMM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteTasks_Tasks_TaskId",
                table: "NoteTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignedContacts_Tasks_TaskId",
                table: "TaskAssignedContacts");

            migrationBuilder.DropTable(
                name: "TaskMatters");

            migrationBuilder.DropIndex(
                name: "IX_TaskAssignedContacts_TaskId",
                table: "TaskAssignedContacts");

            migrationBuilder.DropIndex(
                name: "IX_NoteTasks_TaskId",
                table: "NoteTasks");

            migrationBuilder.AlterColumn<long>(
                name: "SequentialPredecessorId",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "TaskId1",
                table: "TaskAssignedContacts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TaskId1",
                table: "NoteTasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "InnerTaskMatter",
                columns: table => new
                {
                    MattersId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasksId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerTaskMatter", x => new { x.MattersId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_InnerTaskMatter_Matters_MattersId",
                        column: x => x.MattersId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerTaskMatter_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsEligible = table.Column<bool>(type: "boolean", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    Paid = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AdditionalData = table.Column<string>(type: "text", nullable: false),
                    ToId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadFee_Contacts_ToId",
                        column: x => x.ToId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadSourceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    AdditionalQuestion1 = table.Column<string>(type: "text", nullable: false),
                    AdditionalData1 = table.Column<string>(type: "text", nullable: false),
                    AdditionalQuestion2 = table.Column<string>(type: "text", nullable: false),
                    AdditionalData2 = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: true),
                    ContactId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadSource_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeadSource_LeadSourceType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "LeadSourceType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TagBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: false),
                    TagCategoryId = table.Column<int>(type: "integer", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: true),
                    TaskId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagBase_TagCategory_TagCategoryId",
                        column: x => x.TagCategoryId,
                        principalTable: "TagCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TagBase_Tasks_TaskId1",
                        column: x => x.TaskId1,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Stop = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Billable = table.Column<bool>(type: "boolean", nullable: false),
                    WorkerContactId = table.Column<int>(type: "integer", nullable: false),
                    TimeCategoryId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Time_Contacts_WorkerContactId",
                        column: x => x.WorkerContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Time_TimeCategory_TimeCategoryId",
                        column: x => x.TimeCategoryId,
                        principalTable: "TimeCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Closed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    ContactId = table.Column<int>(type: "integer", nullable: true),
                    SourceId = table.Column<int>(type: "integer", nullable: true),
                    FeeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lead_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lead_LeadFee_FeeId",
                        column: x => x.FeeId,
                        principalTable: "LeadFee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lead_LeadSource_SourceId",
                        column: x => x.SourceId,
                        principalTable: "LeadSource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lead_LeadStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "LeadStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    TaskId1 = table.Column<long>(type: "bigint", nullable: false),
                    TimeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskTime_Tasks_TaskId1",
                        column: x => x.TaskId1,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTime_Time_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignedContacts_TaskId1",
                table: "TaskAssignedContacts",
                column: "TaskId1");

            migrationBuilder.CreateIndex(
                name: "IX_NoteTasks_TaskId1",
                table: "NoteTasks",
                column: "TaskId1");

            migrationBuilder.CreateIndex(
                name: "IX_InnerTaskMatter_TasksId",
                table: "InnerTaskMatter",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_ContactId",
                table: "Lead",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_FeeId",
                table: "Lead",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_SourceId",
                table: "Lead",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_StatusId",
                table: "Lead",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadFee_ToId",
                table: "LeadFee",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSource_ContactId",
                table: "LeadSource",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSource_TypeId",
                table: "LeadSource",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TagBase_TagCategoryId",
                table: "TagBase",
                column: "TagCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TagBase_TaskId1",
                table: "TagBase",
                column: "TaskId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTime_TaskId1",
                table: "TaskTime",
                column: "TaskId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTime_TimeId",
                table: "TaskTime",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_TimeCategoryId",
                table: "Time",
                column: "TimeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_WorkerContactId",
                table: "Time",
                column: "WorkerContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTasks_Tasks_TaskId1",
                table: "NoteTasks",
                column: "TaskId1",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignedContacts_Tasks_TaskId1",
                table: "TaskAssignedContacts",
                column: "TaskId1",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteTasks_Tasks_TaskId1",
                table: "NoteTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignedContacts_Tasks_TaskId1",
                table: "TaskAssignedContacts");

            migrationBuilder.DropTable(
                name: "InnerTaskMatter");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "TagBase");

            migrationBuilder.DropTable(
                name: "TaskTime");

            migrationBuilder.DropTable(
                name: "LeadFee");

            migrationBuilder.DropTable(
                name: "LeadSource");

            migrationBuilder.DropTable(
                name: "LeadStatus");

            migrationBuilder.DropTable(
                name: "TagCategory");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "LeadSourceType");

            migrationBuilder.DropTable(
                name: "TimeCategory");

            migrationBuilder.DropIndex(
                name: "IX_TaskAssignedContacts_TaskId1",
                table: "TaskAssignedContacts");

            migrationBuilder.DropIndex(
                name: "IX_NoteTasks_TaskId1",
                table: "NoteTasks");

            migrationBuilder.DropColumn(
                name: "TaskId1",
                table: "TaskAssignedContacts");

            migrationBuilder.DropColumn(
                name: "TaskId1",
                table: "NoteTasks");

            migrationBuilder.AlterColumn<int>(
                name: "SequentialPredecessorId",
                table: "Tasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "TaskMatters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MatterId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMatters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskMatters_Matters_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskMatters_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignedContacts_TaskId",
                table: "TaskAssignedContacts",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteTasks_TaskId",
                table: "NoteTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMatters_MatterId",
                table: "TaskMatters",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMatters_TaskId",
                table: "TaskMatters",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTasks_Tasks_TaskId",
                table: "NoteTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignedContacts_Tasks_TaskId",
                table: "TaskAssignedContacts",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
