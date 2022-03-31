namespace AlecKinler.AdventureGame
{
    public class Character
    {
        public string Name
        {
            get { return (_name != null) ? _name : ""; }
            set { _name = value?.Trim(); }
        }


        private string _name;

        public string Race
        {
            get { return (_race != null) ? _race : ""; }
            set { _race = value?.Trim(); }
        }

        private string _race;

        public string Profession
        {
            get { return (_profession != null) ? _profession : ""; }
            set { _profession = value?.Trim(); }
        }

        private string _profession;

        public int Strength { get; set; }

        public int Intellect { get; set; }

        public int Charisma { get; set; }

        public int Agility { get; set; }

        public int Constitution { get; set; }

        public string Description
        {
            get { return !String.IsNullOrEmpty(_description) ? _description : ""; }
            set { _description = (value != null) ? value.Trim() : null; }
        }

        private string _description;

        private int _minimumValue = 1;

        private int _maximumValue = 100;

        public string Validate()
        {
            if (String.IsNullOrEmpty(_name))
                return "Please name your character";

            if (String.IsNullOrEmpty(_race))
                return "Please choose a race for your character";

            if (String.IsNullOrEmpty(_profession))
                return "Please choose a class for your character";

            if (Strength > _maximumValue || Strength < _minimumValue)
                return $"Value must be between {_minimumValue} and {_maximumValue}";

            if (Intellect > _maximumValue || Intellect < _minimumValue)
                return $"Value must be between {_minimumValue} and {_maximumValue}";

            if (Charisma > _maximumValue || Charisma < _minimumValue)
                return $"Value must be between {_minimumValue} and {_maximumValue}";

            if (Agility > _maximumValue || Agility < _minimumValue)
                return $"Value must be between {_minimumValue} and {_maximumValue}";

            if (Constitution > _maximumValue || Constitution < _minimumValue)
                return $"Value must be between {_minimumValue} and {_maximumValue}";

            //description is optional so no need to validate
            return "";
        }
    }
}