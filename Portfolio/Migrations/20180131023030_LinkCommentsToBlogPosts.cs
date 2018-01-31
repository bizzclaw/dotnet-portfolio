using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class LinkCommentsToBlogPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_blogcomments_BlogPostId",
                table: "blogcomments",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogcomments_blogposts_BlogPostId",
                table: "blogcomments",
                column: "BlogPostId",
                principalTable: "blogposts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogcomments_blogposts_BlogPostId",
                table: "blogcomments");

            migrationBuilder.DropIndex(
                name: "IX_blogcomments_BlogPostId",
                table: "blogcomments");
        }
    }
}
