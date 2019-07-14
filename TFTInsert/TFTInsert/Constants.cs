using System;
using System.Collections.Generic;
using System.Text;

namespace TFTInsert
{
    class Constants
    {
        public const string DeleteOrigin = "DELETE FROM origin;";
        public const string DeleteOriginBonus = "DELETE FROM origin_bonus;";
        public const string DeleteClass = "DELETE FROM class;";
        public const string DeleteClassBonus = "DELETE FROM class_bonus;";
        public const string DeleteChampionOriginLink = "DELETE FROM champion_origin_link";
        public const string DeleteChampionClassLink = "DELETE FROM champion_class_link";
        public const string DeleteChampionStats = "DELETE FROM champion_stat";
        public const string DeleteAbilityStats = "DELETE FROM ability_stat";
        public const string DeleteAbility = "DELETE FROM ability";
        public const string DeleteChampions = "DELETE FROM champion";
        public const string DeleteItemComponentStats = "DELETE FROM item_component_stat";
        public const string DeleteItemLink = "DELETE FROM item_link";
        public const string DeleteItemComponent = "DELETE FROM item_component";
        public const string DeleteItemFull = "DELETE FROM item_full";
    }
}
