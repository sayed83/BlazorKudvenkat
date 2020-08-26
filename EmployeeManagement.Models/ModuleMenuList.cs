using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Models
{
    public class Module
    {

        public int ModuleId { get; set; }

        [Required]
        [Display(Name = "Module Code")]
        public string ModuleCode { get; set; }

        [Required]
        [Display(Name = "Module Name")]
        public string ModuleName { get; set; }
        [Required]
        [Display(Name = "Module Caption")]
        public string ModuleCaption { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Module Description")]
        public string ModuleDescription { get; set; }

        [Display(Name = "Module Link")]
        public string ModuleLink { get; set; }

        [Display(Name = "Module Class a")]
        public string ModuleClassa { get; set; }
        [Display(Name = "Module Class i")]

        public string ModuleClassi { get; set; }

        [Display(Name = "Module Image [DB]")]
        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        public byte[] ModuleImage { get; set; }

        [Display(Name = "Module Image [Folder]")]

        public string ModuleImagePath { get; set; }

        [Display(Name = "Module Image Extension")]
        public string ModuleImageExtension { get; set; }

        [Display(Name = "Is InActive")]
        public int isInactive { get; set; }


        [Display(Name = "SL No.")]
        public Nullable<int> SLNo { get; set; }



        [Display(Name = "Module Group")]
        public virtual ICollection<ModuleGroup> vModuleGroup { get; set; }
    }

    public class ModuleGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleGroupId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Module Group Name")]
        public string ModuleGroupName { get; set; }

        [Required]
        [Display(Name = "Module Group Caption")]
        public string ModuleGroupCaption { get; set; }

        [Required]
        [Display(Name = "Module")]
        public int ModuleId { get; set; }
        public virtual Module vModule { get; set; }


        [Display(Name = "Image [DB]")]
        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        public byte[] ModuleGroupImage { get; set; }

        //[Required]
        //[DataType(DataType.ImageUrl)]

        [Display(Name = "Image [Folder]")]

        public string ImagePath { get; set; }

        [Display(Name = "Image Extension")]
        public string ImageExtension { get; set; }

        [Display(Name = "SL No.")]
        public Nullable<int> SLNo { get; set; }


        [Display(Name = "Module Menu")]
        public virtual ICollection<ModuleMenu> vModuleMenu { get; set; }


    }

    public class ModuleMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModuleMenuId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Module Menu Name")]
        public string ModuleMenuName { get; set; }

        [Required]
        [Display(Name = "Module Menu Caption")]
        public string ModuleMenuCaption { get; set; }

        [Required]
        [Display(Name = "Module Group")]
        public int ModuleGroupId { get; set; }
        public virtual ModuleGroup vModuleGroup { get; set; }

        [Required]
        [Display(Name = "Image Criteria")]
        public int ImageCriteriaId { get; set; }
        public virtual ImageCriteria vImageCriteria { get; set; }

        [Required]
        [Display(Name = "Module")]
        public int ModuleId { get; set; }
        public virtual Module vModule { get; set; }


        [Display(Name = "Image [DB]")]
        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]
        public byte[] ModuleMenuImage { get; set; }

        //[Required]
        //[DataType(DataType.ImageUrl)]
        [Display(Name = "Image [Folder]")]
        public string ModuleImagePath { get; set; }


        [Display(Name = "Image Extension")]
        public string ModuleImageExtension { get; set; }

        public string ModuleMenuController { get; set; }

        public string ModuleMenuLink { get; set; }

        public int isInactive { get; set; }
        public int isParent { get; set; }



        [Display(Name = "SL No.")]
        public Nullable<int> SLNo { get; set; }

        public bool Active { get; set; }


        [ForeignKey("ParentModuleMenu")]
        [Display(Name = "Parent Menu")]
        public int? ParentId { get; set; }
        //public int? ParentBucketGroupId { get; set; }

        public virtual ModuleMenu ParentModuleMenu { get; set; }

        public virtual ICollection<ModuleMenu> ModuleMenuChildren { get; set; }


        [Display(Name = "Module Menu Class i")]

        public string ModuleMenuClassi { get; set; }
        public virtual ICollection<MenuPermission_Details> MenuPermissionDetails { get; set; }


    }

    public class ImageCriteria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageCriteriaId { get; set; }

        public string ImageCriteriaCaption { get; set; }

    }

    public class MenuPermission_Master
    {
        //public MenuPermission_Master()
        //{
        //    this.MenuPermission_Details = new HashSet<MenuPermission_Details>();

        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuPermissionId { get; set; }

        [StringLength(128)]
        [Display(Name = "User")]
        public string useridPermission { get; set; }

        [StringLength(128)]
        public string comid { get; set; }

        [StringLength(128)]
        [Display(Name = "Entry User")]

        public string userid { get; set; }

        [StringLength(128)]
        [Display(Name = "Update By")]

        public string useridUpdate { get; set; }

        [NotMapped]
        public bool Active { get; set; }


        public DateTime? DateAdded { get; set; }

        [StringLength(50)]
        public string Updatedby { get; set; }

        public Nullable<System.DateTime> DateUpdated { get; set; }


        public virtual ICollection<MenuPermission_Details> MenuPermission_Details { get; set; }

    }

    public class MenuPermission_Details
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuPermissionDetailsId { get; set; }


        [ForeignKey("MenuPermissionMasters")]
        public int MenuPermissionId { get; set; }
        public virtual MenuPermission_Master MenuPermissionMasters { get; set; }

        public int ModuleMenuId { get; set; }
        public virtual ModuleMenu ModuleMenus { get; set; }

        public bool IsCreate { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsView { get; set; }
        public bool IsReport { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
