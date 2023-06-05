using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.api.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentFK",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SalaryGrade_SalaryGradeFK",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryGrade",
                table: "SalaryGrade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "SalaryGrade",
                newName: "SalaryGrades");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "SalaryGradeFK",
                table: "Employees",
                newName: "SalaryGradeId");

            migrationBuilder.RenameColumn(
                name: "DepartmentFK",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SalaryGradeFK",
                table: "Employees",
                newName: "IX_Employees_SalaryGradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentFK",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryGrades",
                table: "SalaryGrades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SalaryGrades_SalaryGradeId",
                table: "Employees",
                column: "SalaryGradeId",
                principalTable: "SalaryGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SalaryGrades_SalaryGradeId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalaryGrades",
                table: "SalaryGrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "SalaryGrades",
                newName: "SalaryGrade");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "SalaryGradeId",
                table: "Employees",
                newName: "SalaryGradeFK");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "DepartmentFK");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SalaryGradeId",
                table: "Employees",
                newName: "IX_Employees_SalaryGradeFK");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalaryGrade",
                table: "SalaryGrade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentFK",
                table: "Employees",
                column: "DepartmentFK",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SalaryGrade_SalaryGradeFK",
                table: "Employees",
                column: "SalaryGradeFK",
                principalTable: "SalaryGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
