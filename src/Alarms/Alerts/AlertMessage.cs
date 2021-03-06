﻿namespace WhMgr.Alarms.Alerts
{
    using System;
    using System.Collections.Generic;

    public class AlertMessage : Dictionary<AlertMessageType, AlertMessageSettings>
    {
        public static readonly AlertMessage Defaults = new AlertMessage
        {
            {
                AlertMessageType.Pokemon, new AlertMessageSettings
                {
                    AvatarUrl = "<pkmn_img_url>",
                    Content = "<pkmn_name> <form><gender> <iv> (<atk_iv>/<def_iv>/<sta_iv>) L<lvl><br>**Despawn:** <despawn_time> (<time_left> left)<br>**Details:** CP: <cp> IV: <iv> LV: <lvl><br>**Types:** <types_emoji> | **Size:** <size><#has_weather> | <weather_emoji><#is_weather_boosted> (Boosted)</is_weather_boosted></has_weather><br>**Moveset:** <moveset><br><#near_pokestop>**Near Pokestop:** [<pokestop_name>](<pokestop_url>)<br></near_pokestop><#is_ditto>**Catch Pokemon:** <original_pkmn_name><br></is_ditto><#is_pvp><br><pvp_stats></is_pvp>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "<pkmn_img_url>",
                    Title = "<geofence>",
                    Url = "<gmaps_url>",
                    Username = "<form> <pkmn_name><gender>",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.PokemonMissingStats, new AlertMessageSettings
                {
                    AvatarUrl = "<pkmn_img_url>",
                    Content = "<pkmn_name> <form><gender><br>**Despawn:** <despawn_time> (<time_left> left)<despawn_time_verified><br>**Types:** <types_emoji><br><#near_pokestop>**Near Pokestop:** [<pokestop_name>](<pokestop_url>)<br></near_pokestop>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "<pkmn_img_url>",
                    Title = "<geofence>",
                    Url = "<gmaps_url>",
                    Username = "<form> <pkmn_name><gender>",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.Gyms, new AlertMessageSettings
                {
                    AvatarUrl = "",
                    Content = "<#team_changed>Gym changed from <old_gym_team_emoji> <old_gym_team> to <gym_team_emoji> <gym_team><br></team_changed><#in_battle>Gym is under attack!<br></in_battle>**Slots Available:** <slots_available><br><#is_ex><ex_gym_emoji> Gym!</is_ex>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "",
                    Title = "<geofence>: <gym_name>",
                    Url = "<gmaps_url>",
                    Username = "<gym_name>",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.Raids, new AlertMessageSettings
                {
                    AvatarUrl = "<pkmn_img_url>",
                    //Content = "<pkmn_name> Raid Ends: <end_time><br>**Started:** <start_time><br>**Ends:** <end_time> (<end_time_left> left)<br>**Perfect CP:** <perfect_cp> / :white_sun_rain_cloud: <perfect_cp_boosted><br>**Worst CP:** <worst_cp> / :white_sun_rain_cloud: <worst_cp_boosted><br>**Types:** <types_emoji> | **Level:** <lvl><br>**Moveset:** <moveset><br>**Weaknesses:** <weaknesses_emoji><br>**Team:** <team_emoji><br>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)]**",
                    Content = "<pkmn_name> Raid Ends: <end_time> (<end_time_left> left)<br>**Perfect CP:** <perfect_cp> / :white_sun_rain_cloud: <perfect_cp_boosted><br>**Worst CP:** <worst_cp> / :white_sun_rain_cloud: <worst_cp_boosted><br>**Types:** <types_emoji> | **Level:** <lvl> | **Team:** <team_emoji><br>**Moveset:** <moveset><br>**Weaknesses:** <weaknesses_emoji><br><#is_ex><ex_emoji> Gym!<br></is_ex>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "<pkmn_img_url>",
                    Title = "<geofence>: <gym_name>",
                    Url = "<gmaps_url>",
                    Username = "<pkmn_form> <pkmn_name> Raid",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.Eggs, new AlertMessageSettings
                {
                    AvatarUrl = "<pkmn_img_url>",
                    Content = "Hatches: <start_time> (<start_time_left>)<br>**Ends:** <end_time> (<end_time_left> left)<br>**Team:** <team_emoji><br><#is_ex><ex_emoji> Gym!<br></is_ex>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "<pkmn_img_url>",
                    Title = "<geofence>: <gym_name>",
                    Url = "<gmaps_url>",
                    Username = "Level <lvl> Egg",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.Pokestops, new AlertMessageSettings
                {
                    AvatarUrl = "",
                    Content = "<#has_lure>**Lure Expires** <lure_expire_time> (<lure_expire_time_left> left)<br>**Lure Type:** <lure_type><br></has_lure><#has_invasion>**Expires:** <invasion_expire_time> (<invasion_expire_time_left> left)<br>**Type:** <grunt_type_emoji> | **Gender:** <grunt_gender><br><invasion_encounters><br></has_invasion>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "",
                    Title = "<geofence>: <pokestop_name>",
                    Url = "<gmaps_url>",
                    Username = "<pokestop_name>",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.Quests, new AlertMessageSettings
                {
                    AvatarUrl = "<quest_reward_img_url>",
                    Content = "**Quest:** <quest_task><br><#has_quest_conditions>**Condition(s):** <quest_conditions><br></has_quest_conditions>**Reward:** <quest_reward><br>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "<pokestop_url>",
                    Title = "<geofence>: <pokestop_name>",
                    Url = "<gmaps_url>",
                    Username = "<quest_task>",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.Invasions, new AlertMessageSettings
                {
                    AvatarUrl = "", //TODO: Invasions IconUrl
                    Content = "<#has_invasion>**Expires:** <invasion_expire_time> (<invasion_expire_time_left> left)<br>**Type:** <grunt_type_emoji> | **Gender:** <grunt_gender><br><invasion_encounters><br></has_invasion>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "<pokestop_url>",
                    Title = "<geofence>: <pokestop_name>",
                    Url = "<gmaps_url>",
                    Username = "<pokestop_name>",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.Lures, new AlertMessageSettings
                {
                    AvatarUrl = "", //TODO: Lures IconUrl
                    Content = "<#has_lure>**Lure Expires:** <lure_expire_time> (<lure_expire_time_left> left)<br>**Lure Type:** <lure_type><br></has_lure>**[[Google Maps](<gmaps_url>)] [[Apple Maps](<applemaps_url>)] [[Waze Maps](<wazemaps_url>)]**",
                    IconUrl = "<pokestop_url>",
                    Title = "<geofence>: <pokestop_name>",
                    Url = "<gmaps_url>",
                    Username = "<pokestop_name>",
                    ImageUrl = "<tilemaps_url>"
                }
            },
            {
                AlertMessageType.Nests, new AlertMessageSettings
                {
                    AvatarUrl = "",
                    Content = "**Pokemon:** <pkmn_name><br>**Average Spawns:** {<avg_spawns>}/h | **Types:** <type_emojis>\r\n**[[Google Maps]({gmapsLink})] [[Apple Maps]({appleMapsLink})] [[Waze Maps]({wazeMapsLink})]**",
                    IconUrl = "<pkmn_img_url>",
                    Title = "<geofence>: <nest_name>",
                    Url = "<gmaps_url>",
                    Username = "",
                    ImageUrl = "<tilemaps_url>"
                }
            }
        };
    }
}