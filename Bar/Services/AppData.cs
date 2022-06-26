namespace Bar.Services
{
    public class AppData
    {
        private decimal _credit;
        public decimal Credit
        {
            get
            {
                return _credit;
            }
            set
            {
                _credit = value;
                NotifyDataChanged();
            }
        }

        public event Action OnChange;

        private void NotifyDataChanged() => OnChange?.Invoke();

    }
}
