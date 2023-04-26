using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMatterTaskTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingGroup_Contacts_BillToContactId",
                table: "BillingGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MatterType_MatterTypeId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Matter_BillingGroup_BillingGroupId",
                table: "Matter");

            migrationBuilder.DropForeignKey(
                name: "FK_Matter_BillingRates_DefaultBillingRateId",
                table: "Matter");

            migrationBuilder.DropForeignKey(
                name: "FK_Matter_Contacts_BillToContactId",
                table: "Matter");

            migrationBuilder.DropForeignKey(
                name: "FK_Matter_CourtGeographicalJurisdiction_CourtGeographicalJuris~",
                table: "Matter");

            migrationBuilder.DropForeignKey(
                name: "FK_Matter_CourtSittingInCity_CourtSittingInCityId",
                table: "Matter");

            migrationBuilder.DropForeignKey(
                name: "FK_Matter_MatterArea_MatterAreaId",
                table: "Matter");

            migrationBuilder.DropForeignKey(
                name: "FK_Matter_MatterType_MatterTypeId",
                table: "Matter");

            migrationBuilder.DropForeignKey(
                name: "FK_MatterContact_Contacts_ContactId",
                table: "MatterContact");

            migrationBuilder.DropForeignKey(
                name: "FK_MatterContact_Matter_MatterId",
                table: "MatterContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskType_TaskTypeId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Task_SequentialPredecessorId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignedContact_Contacts_ContactId",
                table: "TaskAssignedContact");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignedContact_Task_TaskId",
                table: "TaskAssignedContact");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskMatter_Matter_MatterId",
                table: "TaskMatter");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskMatter_Task_TaskId",
                table: "TaskMatter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskType",
                table: "TaskType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskMatter",
                table: "TaskMatter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAssignedContact",
                table: "TaskAssignedContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatterType",
                table: "MatterType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatterContact",
                table: "MatterContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatterArea",
                table: "MatterArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matter",
                table: "Matter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourtSittingInCity",
                table: "CourtSittingInCity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourtGeographicalJurisdiction",
                table: "CourtGeographicalJurisdiction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillingGroup",
                table: "BillingGroup");

            migrationBuilder.RenameTable(
                name: "TaskType",
                newName: "TaskTypes");

            migrationBuilder.RenameTable(
                name: "TaskMatter",
                newName: "TaskMatters");

            migrationBuilder.RenameTable(
                name: "TaskAssignedContact",
                newName: "TaskAssignedContacts");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "MatterType",
                newName: "MatterTypes");

            migrationBuilder.RenameTable(
                name: "MatterContact",
                newName: "MatterContacts");

            migrationBuilder.RenameTable(
                name: "MatterArea",
                newName: "MatterAreas");

            migrationBuilder.RenameTable(
                name: "Matter",
                newName: "Matters");

            migrationBuilder.RenameTable(
                name: "CourtSittingInCity",
                newName: "CourtSittingInCities");

            migrationBuilder.RenameTable(
                name: "CourtGeographicalJurisdiction",
                newName: "CourtGeographicalJurisdictions");

            migrationBuilder.RenameTable(
                name: "BillingGroup",
                newName: "BillingGroups");

            migrationBuilder.RenameIndex(
                name: "IX_TaskMatter_TaskId",
                table: "TaskMatters",
                newName: "IX_TaskMatters_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskMatter_MatterId",
                table: "TaskMatters",
                newName: "IX_TaskMatters_MatterId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignedContact_TaskId",
                table: "TaskAssignedContacts",
                newName: "IX_TaskAssignedContacts_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignedContact_ContactId",
                table: "TaskAssignedContacts",
                newName: "IX_TaskAssignedContacts_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_TaskTypeId",
                table: "Tasks",
                newName: "IX_Tasks_TaskTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_SequentialPredecessorId",
                table: "Tasks",
                newName: "IX_Tasks_SequentialPredecessorId");

            migrationBuilder.RenameIndex(
                name: "IX_MatterContact_MatterId",
                table: "MatterContacts",
                newName: "IX_MatterContacts_MatterId");

            migrationBuilder.RenameIndex(
                name: "IX_MatterContact_ContactId",
                table: "MatterContacts",
                newName: "IX_MatterContacts_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Matter_MatterTypeId",
                table: "Matters",
                newName: "IX_Matters_MatterTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Matter_MatterAreaId",
                table: "Matters",
                newName: "IX_Matters_MatterAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Matter_DefaultBillingRateId",
                table: "Matters",
                newName: "IX_Matters_DefaultBillingRateId");

            migrationBuilder.RenameIndex(
                name: "IX_Matter_CourtSittingInCityId",
                table: "Matters",
                newName: "IX_Matters_CourtSittingInCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Matter_CourtGeographicalJurisdictionId",
                table: "Matters",
                newName: "IX_Matters_CourtGeographicalJurisdictionId");

            migrationBuilder.RenameIndex(
                name: "IX_Matter_BillToContactId",
                table: "Matters",
                newName: "IX_Matters_BillToContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Matter_BillingGroupId",
                table: "Matters",
                newName: "IX_Matters_BillingGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_BillingGroup_BillToContactId",
                table: "BillingGroups",
                newName: "IX_BillingGroups_BillToContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskMatters",
                table: "TaskMatters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAssignedContacts",
                table: "TaskAssignedContacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatterTypes",
                table: "MatterTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatterContacts",
                table: "MatterContacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatterAreas",
                table: "MatterAreas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matters",
                table: "Matters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourtSittingInCities",
                table: "CourtSittingInCities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourtGeographicalJurisdictions",
                table: "CourtGeographicalJurisdictions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillingGroups",
                table: "BillingGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingGroups_Contacts_BillToContactId",
                table: "BillingGroups",
                column: "BillToContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MatterTypes_MatterTypeId",
                table: "Contacts",
                column: "MatterTypeId",
                principalTable: "MatterTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatterContacts_Contacts_ContactId",
                table: "MatterContacts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatterContacts_Matters_MatterId",
                table: "MatterContacts",
                column: "MatterId",
                principalTable: "Matters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matters_BillingGroups_BillingGroupId",
                table: "Matters",
                column: "BillingGroupId",
                principalTable: "BillingGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matters_BillingRates_DefaultBillingRateId",
                table: "Matters",
                column: "DefaultBillingRateId",
                principalTable: "BillingRates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matters_Contacts_BillToContactId",
                table: "Matters",
                column: "BillToContactId",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matters_CourtGeographicalJurisdictions_CourtGeographicalJur~",
                table: "Matters",
                column: "CourtGeographicalJurisdictionId",
                principalTable: "CourtGeographicalJurisdictions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matters_CourtSittingInCities_CourtSittingInCityId",
                table: "Matters",
                column: "CourtSittingInCityId",
                principalTable: "CourtSittingInCities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matters_MatterAreas_MatterAreaId",
                table: "Matters",
                column: "MatterAreaId",
                principalTable: "MatterAreas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matters_MatterTypes_MatterTypeId",
                table: "Matters",
                column: "MatterTypeId",
                principalTable: "MatterTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignedContacts_Contacts_ContactId",
                table: "TaskAssignedContacts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignedContacts_Tasks_TaskId",
                table: "TaskAssignedContacts",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMatters_Matters_MatterId",
                table: "TaskMatters",
                column: "MatterId",
                principalTable: "Matters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMatters_Tasks_TaskId",
                table: "TaskMatters",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_SequentialPredecessorId",
                table: "Tasks",
                column: "SequentialPredecessorId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingGroups_Contacts_BillToContactId",
                table: "BillingGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_MatterTypes_MatterTypeId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_MatterContacts_Contacts_ContactId",
                table: "MatterContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_MatterContacts_Matters_MatterId",
                table: "MatterContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Matters_BillingGroups_BillingGroupId",
                table: "Matters");

            migrationBuilder.DropForeignKey(
                name: "FK_Matters_BillingRates_DefaultBillingRateId",
                table: "Matters");

            migrationBuilder.DropForeignKey(
                name: "FK_Matters_Contacts_BillToContactId",
                table: "Matters");

            migrationBuilder.DropForeignKey(
                name: "FK_Matters_CourtGeographicalJurisdictions_CourtGeographicalJur~",
                table: "Matters");

            migrationBuilder.DropForeignKey(
                name: "FK_Matters_CourtSittingInCities_CourtSittingInCityId",
                table: "Matters");

            migrationBuilder.DropForeignKey(
                name: "FK_Matters_MatterAreas_MatterAreaId",
                table: "Matters");

            migrationBuilder.DropForeignKey(
                name: "FK_Matters_MatterTypes_MatterTypeId",
                table: "Matters");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignedContacts_Contacts_ContactId",
                table: "TaskAssignedContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignedContacts_Tasks_TaskId",
                table: "TaskAssignedContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskMatters_Matters_MatterId",
                table: "TaskMatters");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskMatters_Tasks_TaskId",
                table: "TaskMatters");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_SequentialPredecessorId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskMatters",
                table: "TaskMatters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAssignedContacts",
                table: "TaskAssignedContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatterTypes",
                table: "MatterTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matters",
                table: "Matters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatterContacts",
                table: "MatterContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatterAreas",
                table: "MatterAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourtSittingInCities",
                table: "CourtSittingInCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourtGeographicalJurisdictions",
                table: "CourtGeographicalJurisdictions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillingGroups",
                table: "BillingGroups");

            migrationBuilder.RenameTable(
                name: "TaskTypes",
                newName: "TaskType");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "TaskMatters",
                newName: "TaskMatter");

            migrationBuilder.RenameTable(
                name: "TaskAssignedContacts",
                newName: "TaskAssignedContact");

            migrationBuilder.RenameTable(
                name: "MatterTypes",
                newName: "MatterType");

            migrationBuilder.RenameTable(
                name: "Matters",
                newName: "Matter");

            migrationBuilder.RenameTable(
                name: "MatterContacts",
                newName: "MatterContact");

            migrationBuilder.RenameTable(
                name: "MatterAreas",
                newName: "MatterArea");

            migrationBuilder.RenameTable(
                name: "CourtSittingInCities",
                newName: "CourtSittingInCity");

            migrationBuilder.RenameTable(
                name: "CourtGeographicalJurisdictions",
                newName: "CourtGeographicalJurisdiction");

            migrationBuilder.RenameTable(
                name: "BillingGroups",
                newName: "BillingGroup");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Task",
                newName: "IX_Task_TaskTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_SequentialPredecessorId",
                table: "Task",
                newName: "IX_Task_SequentialPredecessorId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskMatters_TaskId",
                table: "TaskMatter",
                newName: "IX_TaskMatter_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskMatters_MatterId",
                table: "TaskMatter",
                newName: "IX_TaskMatter_MatterId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignedContacts_TaskId",
                table: "TaskAssignedContact",
                newName: "IX_TaskAssignedContact_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignedContacts_ContactId",
                table: "TaskAssignedContact",
                newName: "IX_TaskAssignedContact_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Matters_MatterTypeId",
                table: "Matter",
                newName: "IX_Matter_MatterTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Matters_MatterAreaId",
                table: "Matter",
                newName: "IX_Matter_MatterAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Matters_DefaultBillingRateId",
                table: "Matter",
                newName: "IX_Matter_DefaultBillingRateId");

            migrationBuilder.RenameIndex(
                name: "IX_Matters_CourtSittingInCityId",
                table: "Matter",
                newName: "IX_Matter_CourtSittingInCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Matters_CourtGeographicalJurisdictionId",
                table: "Matter",
                newName: "IX_Matter_CourtGeographicalJurisdictionId");

            migrationBuilder.RenameIndex(
                name: "IX_Matters_BillToContactId",
                table: "Matter",
                newName: "IX_Matter_BillToContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Matters_BillingGroupId",
                table: "Matter",
                newName: "IX_Matter_BillingGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_MatterContacts_MatterId",
                table: "MatterContact",
                newName: "IX_MatterContact_MatterId");

            migrationBuilder.RenameIndex(
                name: "IX_MatterContacts_ContactId",
                table: "MatterContact",
                newName: "IX_MatterContact_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_BillingGroups_BillToContactId",
                table: "BillingGroup",
                newName: "IX_BillingGroup_BillToContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskType",
                table: "TaskType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskMatter",
                table: "TaskMatter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAssignedContact",
                table: "TaskAssignedContact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatterType",
                table: "MatterType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matter",
                table: "Matter",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatterContact",
                table: "MatterContact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatterArea",
                table: "MatterArea",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourtSittingInCity",
                table: "CourtSittingInCity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourtGeographicalJurisdiction",
                table: "CourtGeographicalJurisdiction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillingGroup",
                table: "BillingGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingGroup_Contacts_BillToContactId",
                table: "BillingGroup",
                column: "BillToContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_MatterType_MatterTypeId",
                table: "Contacts",
                column: "MatterTypeId",
                principalTable: "MatterType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matter_BillingGroup_BillingGroupId",
                table: "Matter",
                column: "BillingGroupId",
                principalTable: "BillingGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matter_BillingRates_DefaultBillingRateId",
                table: "Matter",
                column: "DefaultBillingRateId",
                principalTable: "BillingRates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matter_Contacts_BillToContactId",
                table: "Matter",
                column: "BillToContactId",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matter_CourtGeographicalJurisdiction_CourtGeographicalJuris~",
                table: "Matter",
                column: "CourtGeographicalJurisdictionId",
                principalTable: "CourtGeographicalJurisdiction",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matter_CourtSittingInCity_CourtSittingInCityId",
                table: "Matter",
                column: "CourtSittingInCityId",
                principalTable: "CourtSittingInCity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matter_MatterArea_MatterAreaId",
                table: "Matter",
                column: "MatterAreaId",
                principalTable: "MatterArea",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matter_MatterType_MatterTypeId",
                table: "Matter",
                column: "MatterTypeId",
                principalTable: "MatterType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatterContact_Contacts_ContactId",
                table: "MatterContact",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatterContact_Matter_MatterId",
                table: "MatterContact",
                column: "MatterId",
                principalTable: "Matter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskType_TaskTypeId",
                table: "Task",
                column: "TaskTypeId",
                principalTable: "TaskType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Task_SequentialPredecessorId",
                table: "Task",
                column: "SequentialPredecessorId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignedContact_Contacts_ContactId",
                table: "TaskAssignedContact",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignedContact_Task_TaskId",
                table: "TaskAssignedContact",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMatter_Matter_MatterId",
                table: "TaskMatter",
                column: "MatterId",
                principalTable: "Matter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMatter_Task_TaskId",
                table: "TaskMatter",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
