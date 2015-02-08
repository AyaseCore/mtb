﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSAToolBox
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LegacyWorldEntities : DbContext
    {
        public LegacyWorldEntities()
            : base("name=LegacyWorldEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<access_requirement> access_requirement { get; set; }
        public DbSet<achievement_criteria_data> achievement_criteria_data { get; set; }
        public DbSet<achievement_dbc> achievement_dbc { get; set; }
        public DbSet<achievement_reward> achievement_reward { get; set; }
        public DbSet<areatrigger_involvedrelation> areatrigger_involvedrelation { get; set; }
        public DbSet<areatrigger_scripts> areatrigger_scripts { get; set; }
        public DbSet<areatrigger_tavern> areatrigger_tavern { get; set; }
        public DbSet<areatrigger_teleport> areatrigger_teleport { get; set; }
        public DbSet<battleground_template> battleground_template { get; set; }
        public DbSet<battlemaster_entry> battlemaster_entry { get; set; }
        public DbSet<broadcast_text> broadcast_text { get; set; }
        public DbSet<capital_cities> capital_cities { get; set; }
        public DbSet<command> command { get; set; }
        public DbSet<conditions> conditions { get; set; }
        public DbSet<creature> creature { get; set; }
        public DbSet<creature_addon> creature_addon { get; set; }
        public DbSet<creature_classlevelstats> creature_classlevelstats { get; set; }
        public DbSet<creature_equip_template> creature_equip_template { get; set; }
        public DbSet<creature_formations> creature_formations { get; set; }
        public DbSet<creature_loot_template> creature_loot_template { get; set; }
        public DbSet<creature_model_info> creature_model_info { get; set; }
        public DbSet<creature_onkill_reputation> creature_onkill_reputation { get; set; }
        public DbSet<creature_questender> creature_questender { get; set; }
        public DbSet<creature_queststarter> creature_queststarter { get; set; }
        public DbSet<creature_template> creature_template { get; set; }
        public DbSet<creature_template_addon> creature_template_addon { get; set; }
        public DbSet<creature_text> creature_text { get; set; }
        public DbSet<disables> disables { get; set; }
        public DbSet<disenchant_loot_template> disenchant_loot_template { get; set; }
        public DbSet<exploration_basexp> exploration_basexp { get; set; }
        public DbSet<fishing_loot_template> fishing_loot_template { get; set; }
        public DbSet<game_event> game_event { get; set; }
        public DbSet<game_event_battleground_holiday> game_event_battleground_holiday { get; set; }
        public DbSet<game_event_condition> game_event_condition { get; set; }
        public DbSet<game_event_creature> game_event_creature { get; set; }
        public DbSet<game_event_creature_quest> game_event_creature_quest { get; set; }
        public DbSet<game_event_gameobject> game_event_gameobject { get; set; }
        public DbSet<game_event_gameobject_quest> game_event_gameobject_quest { get; set; }
        public DbSet<game_event_model_equip> game_event_model_equip { get; set; }
        public DbSet<game_event_npc_vendor> game_event_npc_vendor { get; set; }
        public DbSet<game_event_npcflag> game_event_npcflag { get; set; }
        public DbSet<game_event_pool> game_event_pool { get; set; }
        public DbSet<game_event_prerequisite> game_event_prerequisite { get; set; }
        public DbSet<game_event_quest_condition> game_event_quest_condition { get; set; }
        public DbSet<game_event_seasonal_questrelation> game_event_seasonal_questrelation { get; set; }
        public DbSet<game_graveyard_zone> game_graveyard_zone { get; set; }
        public DbSet<game_tele> game_tele { get; set; }
        public DbSet<game_weather> game_weather { get; set; }
        public DbSet<gameobject> gameobject { get; set; }
        public DbSet<gameobject_loot_template> gameobject_loot_template { get; set; }
        public DbSet<gameobject_questender> gameobject_questender { get; set; }
        public DbSet<gameobject_queststarter> gameobject_queststarter { get; set; }
        public DbSet<gameobject_template> gameobject_template { get; set; }
        public DbSet<gossip_menu> gossip_menu { get; set; }
        public DbSet<gossip_menu_option> gossip_menu_option { get; set; }
        public DbSet<instance_encounters> instance_encounters { get; set; }
        public DbSet<instance_template> instance_template { get; set; }
        public DbSet<item_enchantment_template> item_enchantment_template { get; set; }
        public DbSet<item_loot_template> item_loot_template { get; set; }
        public DbSet<item_set_names> item_set_names { get; set; }
        public DbSet<item_template> item_template { get; set; }
        public DbSet<lfg_dungeon_rewards> lfg_dungeon_rewards { get; set; }
        public DbSet<lfg_entrances> lfg_entrances { get; set; }
        public DbSet<linked_respawn> linked_respawn { get; set; }
        public DbSet<locales_achievement_reward> locales_achievement_reward { get; set; }
        public DbSet<locales_broadcast_text> locales_broadcast_text { get; set; }
        public DbSet<locales_creature> locales_creature { get; set; }
        public DbSet<locales_creature_text> locales_creature_text { get; set; }
        public DbSet<locales_gameobject> locales_gameobject { get; set; }
        public DbSet<locales_gossip_menu_option> locales_gossip_menu_option { get; set; }
        public DbSet<locales_item> locales_item { get; set; }
        public DbSet<locales_item_set_names> locales_item_set_names { get; set; }
        public DbSet<locales_npc_text> locales_npc_text { get; set; }
        public DbSet<locales_page_text> locales_page_text { get; set; }
        public DbSet<locales_points_of_interest> locales_points_of_interest { get; set; }
        public DbSet<locales_quest> locales_quest { get; set; }
        public DbSet<loot_pool> loot_pool { get; set; }
        public DbSet<mail_level_reward> mail_level_reward { get; set; }
        public DbSet<mail_loot_template> mail_loot_template { get; set; }
        public DbSet<milling_loot_template> milling_loot_template { get; set; }
        public DbSet<npc_spellclick_spells> npc_spellclick_spells { get; set; }
        public DbSet<npc_text> npc_text { get; set; }
        public DbSet<npc_trainer> npc_trainer { get; set; }
        public DbSet<npc_vendor> npc_vendor { get; set; }
        public DbSet<outdoorpvp_template> outdoorpvp_template { get; set; }
        public DbSet<page_text> page_text { get; set; }
        public DbSet<pet_levelstats> pet_levelstats { get; set; }
        public DbSet<pet_name_generation> pet_name_generation { get; set; }
        public DbSet<pickpocketing_loot_template> pickpocketing_loot_template { get; set; }
        public DbSet<player_classlevelstats> player_classlevelstats { get; set; }
        public DbSet<player_factionchange_achievement> player_factionchange_achievement { get; set; }
        public DbSet<player_factionchange_items> player_factionchange_items { get; set; }
        public DbSet<player_factionchange_quests> player_factionchange_quests { get; set; }
        public DbSet<player_factionchange_reputations> player_factionchange_reputations { get; set; }
        public DbSet<player_factionchange_spells> player_factionchange_spells { get; set; }
        public DbSet<player_factionchange_titles> player_factionchange_titles { get; set; }
        public DbSet<player_level_spell> player_level_spell { get; set; }
        public DbSet<player_levelstats> player_levelstats { get; set; }
        public DbSet<player_xp_for_level> player_xp_for_level { get; set; }
        public DbSet<playercreateinfo> playercreateinfo { get; set; }
        public DbSet<playercreateinfo_action> playercreateinfo_action { get; set; }
        public DbSet<playercreateinfo_item> playercreateinfo_item { get; set; }
        public DbSet<playercreateinfo_skills> playercreateinfo_skills { get; set; }
        public DbSet<playercreateinfo_spell_custom> playercreateinfo_spell_custom { get; set; }
        public DbSet<points_of_interest> points_of_interest { get; set; }
        public DbSet<pool_creature> pool_creature { get; set; }
        public DbSet<pool_gameobject> pool_gameobject { get; set; }
        public DbSet<pool_pool> pool_pool { get; set; }
        public DbSet<pool_quest> pool_quest { get; set; }
        public DbSet<pool_template> pool_template { get; set; }
        public DbSet<prospecting_loot_template> prospecting_loot_template { get; set; }
        public DbSet<quest_poi> quest_poi { get; set; }
        public DbSet<quest_poi_points> quest_poi_points { get; set; }
        public DbSet<quest_template> quest_template { get; set; }
        public DbSet<random_enchantment> random_enchantment { get; set; }
        public DbSet<reference_loot_template> reference_loot_template { get; set; }
        public DbSet<reputation_reward_rate> reputation_reward_rate { get; set; }
        public DbSet<reputation_spillover_template> reputation_spillover_template { get; set; }
        public DbSet<resource_points> resource_points { get; set; }
        public DbSet<script_waypoint> script_waypoint { get; set; }
        public DbSet<server_messages> server_messages { get; set; }
        public DbSet<skill_discovery_template> skill_discovery_template { get; set; }
        public DbSet<skill_extra_item_template> skill_extra_item_template { get; set; }
        public DbSet<skill_fishing_base_level> skill_fishing_base_level { get; set; }
        public DbSet<skinning_loot_template> skinning_loot_template { get; set; }
        public DbSet<smart_scripts> smart_scripts { get; set; }
        public DbSet<spell_area> spell_area { get; set; }
        public DbSet<spell_bonus_data> spell_bonus_data { get; set; }
        public DbSet<spell_custom_attr> spell_custom_attr { get; set; }
        public DbSet<spell_dbc> spell_dbc { get; set; }
        public DbSet<spell_enchant_proc_data> spell_enchant_proc_data { get; set; }
        public DbSet<spell_group> spell_group { get; set; }
        public DbSet<spell_group_stack_rules> spell_group_stack_rules { get; set; }
        public DbSet<spell_learn_spell> spell_learn_spell { get; set; }
        public DbSet<spell_loot_template> spell_loot_template { get; set; }
        public DbSet<spell_pet_auras> spell_pet_auras { get; set; }
        public DbSet<spell_proc> spell_proc { get; set; }
        public DbSet<spell_proc_event> spell_proc_event { get; set; }
        public DbSet<spell_ranks> spell_ranks { get; set; }
        public DbSet<spell_required> spell_required { get; set; }
        public DbSet<spell_target_position> spell_target_position { get; set; }
        public DbSet<spell_threat> spell_threat { get; set; }
        public DbSet<spelldifficulty_dbc> spelldifficulty_dbc { get; set; }
        public DbSet<supremacy_level_xp> supremacy_level_xp { get; set; }
        public DbSet<transports> transports { get; set; }
        public DbSet<trinity_string> trinity_string { get; set; }
        public DbSet<vehicle_accessory> vehicle_accessory { get; set; }
        public DbSet<vehicle_template_accessory> vehicle_template_accessory { get; set; }
        public DbSet<version> version { get; set; }
        public DbSet<war_school> war_school { get; set; }
        public DbSet<war_school_spell> war_school_spell { get; set; }
        public DbSet<warden_checks> warden_checks { get; set; }
        public DbSet<waypoint_data> waypoint_data { get; set; }
        public DbSet<waypoint_scripts> waypoint_scripts { get; set; }
        public DbSet<waypoints> waypoints { get; set; }
        public DbSet<creature_summon_groups> creature_summon_groups { get; set; }
        public DbSet<event_scripts> event_scripts { get; set; }
        public DbSet<game_event_arena_seasons> game_event_arena_seasons { get; set; }
        public DbSet<spell_linked_spell> spell_linked_spell { get; set; }
        public DbSet<spell_script_names> spell_script_names { get; set; }
        public DbSet<spell_scripts> spell_scripts { get; set; }
    }
}
