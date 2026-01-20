using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheWindCorner.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "The username of the user"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "The first name of the user"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "The last name of the user"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "The phone number of the user"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time when the user has been created"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The date and time when the user has been modified"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "If the user has been deleted"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "The date and time when the user has been deleted"),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Image Identifier"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "A short descriptive title for the image"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Text added to the image"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The path to the image")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the notification"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time the notification was sent"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the item, that was commented"),
                    EntityType = table.Column<int>(type: "int", nullable: false, comment: "The type of the entity"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, whose action triggered the notification")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Notification to the admin about user's action");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Item Identifier"),
                    Category = table.Column<int>(type: "int", nullable: false, comment: "The Category of the Item"),
                    ItemType = table.Column<int>(type: "int", nullable: false, comment: "The Type of the Item"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "A short descriptive title for the item"),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "The Size of the Item"),
                    Brand = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true, comment: "The Brand Name of the Item"),
                    Model = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true, comment: "The Model Name of the Item"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "The Year of the Item's production or collection"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "The Price of the Item"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "A full description of the item"),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time, when the item was listed for sale"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, comment: "If the Item has been approved for listing"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "If the Item has been deleted"),
                    IsSold = table.Column<bool>(type: "bit", nullable: false, comment: "If the Item has been sold"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Identifier of the Item's Owner")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                },
                comment: "Item listed for sale");

            migrationBuilder.CreateTable(
                name: "Spots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the spot"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the spot"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "A full description of the spot"),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false, comment: "The latitude of the spot's location"),
                    Longitude = table.Column<double>(type: "float", nullable: false, comment: "The longitude of the spot's location"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time, when the spot was added"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "If the spot has been deleted"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, comment: "If the spot has been approved for listing"),
                    AddedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, who added the spot")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spots_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spots_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                },
                comment: "A location, where one of the wind-sports can be practiced");

            migrationBuilder.CreateTable(
                name: "WantedItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the wanted item"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, comment: "A short descriptive title for the wanted item"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "A full description of the wanted item"),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time, when the sought item was listed"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user seeking the item")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WantedItems_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WantedItems_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                },
                comment: "Item that an user is looking for");

            migrationBuilder.CreateTable(
                name: "ItemComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the comment made"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The full text of the comment"),
                    CommentedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time the comment was added or edited"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "If the comment has been deleted"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, who made the comment"),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the item, that was commented")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemComments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemComments_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "The comment on an item");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Event Identifier"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "A short descriptive title for the event"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "A description of the event"),
                    FullInfo = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "A full description of the event"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time, when the event starts"),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time, when the event ends"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The location, where the event is to be held"),
                    SpotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "The status of the event")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Events_Spots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "Spots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpotComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the comment made"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "The full text of the comment"),
                    CommentedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time the comment was added or edited"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "If the comment has been deleted"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, who made the comment"),
                    SpotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the spot, that was commented")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpotComments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpotComments_Spots_SpotId",
                        column: x => x.SpotId,
                        principalTable: "Spots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "The comment on an spot");

            migrationBuilder.CreateTable(
                name: "WantedItemComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the comment made"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The full text of the comment"),
                    CommentedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time the comment was added or edited"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "If the comment has been deleted"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, who made the comment"),
                    WantedItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the item, that was commented")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantedItemComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WantedItemComments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WantedItemComments_WantedItems_WantedItemId",
                        column: x => x.WantedItemId,
                        principalTable: "WantedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "The comment on an wanted item");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ImageId",
                table: "Events",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SpotId",
                table: "Events",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComments_ItemId",
                table: "ItemComments",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComments_OwnerId",
                table: "ItemComments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ImageId",
                table: "Items",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OwnerId",
                table: "Items",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OwnerId",
                table: "Notifications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotComments_OwnerId",
                table: "SpotComments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotComments_SpotId",
                table: "SpotComments",
                column: "SpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Spots_AddedByUserId",
                table: "Spots",
                column: "AddedByUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spots_ImageId",
                table: "Spots",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_WantedItemComments_OwnerId",
                table: "WantedItemComments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WantedItemComments_WantedItemId",
                table: "WantedItemComments",
                column: "WantedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WantedItems_ImageId",
                table: "WantedItems",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_WantedItems_OwnerId",
                table: "WantedItems",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ItemComments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SpotComments");

            migrationBuilder.DropTable(
                name: "WantedItemComments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Spots");

            migrationBuilder.DropTable(
                name: "WantedItems");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
