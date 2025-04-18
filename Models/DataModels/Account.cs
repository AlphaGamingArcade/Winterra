using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Winterra.Models.DataModels
{
    public class Account
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        public string? DeviceId { get; set; }
        public int Stellar { get; set; }
        public int IsOnline { get; set; }
        public int ClientId { get; set; }
        public int Trophies { get; set; }
        public int Banned { get; set; }
        public DateTime? Shield { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public DateTime? ClanJoinTimer { get; set; }
        public int ClanId { get; set; }
        public int ClanRank { get; set; }
        public int WarId { get; set; }
        public int GlobalChatBlocked { get; set; }
        public DateTime? LastChat { get; set; }
        public string? ChatColor { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int MapLayout { get; set; }
        public DateTime? ShieldCouldron1 { get; set; }
        public DateTime? ShieldCouldron2 { get; set; }
        public DateTime? ShieldCouldron3 { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? CampaignLevel { get; set; }
        public int Admin { get; set; }
        public string? Verified { get; set; }

        public string? Session { get; set; }
    }
}
