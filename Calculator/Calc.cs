using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator
{
    public class ListItem : INotifyPropertyChanged
    {
        public ListItem(double value)
        {
            Value = value;
        }

        private double _value;
        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Calc : INotifyPropertyChanged
    {
        public Calc()
        {
            InputCommand = new CustomCommand<MathOperations>(Input);

            ListItemReadCommand = new CustomCommand<ListItem>(x => Display = x.Value);
            ListItemDeleteCommand = new CustomCommand<ListItem>(ListItemDelete);

            MemoryPlusCommand = new CustomCommand<ListItem>(x => x.Value += Display);
            MemoryMinusCommand = new CustomCommand<ListItem>(x => x.Value -= Display);
        }

        private double? _operand1, _operand2;
        private MathOperations? _operation;

        public ICommand InputCommand { get; }

        public ICommand ListItemReadCommand { get; }
        public ICommand ListItemDeleteCommand { get; }

        public ICommand MemoryPlusCommand { get; }
        public ICommand MemoryMinusCommand { get; }

        public ObservableCollection<ListItem> HistoryList { get; } = new ObservableCollection<ListItem>();
        public ObservableCollection<ListItem> MemoryList { get; } = new ObservableCollection<ListItem>();

        private double _display;
        public double Display
        {
            get => _display;
            private set
            {
                _display = value;
                OnPropertyChanged();
            }
        }

        private string DisplayText
        {
            get => Display.ToString(CultureInfo.InvariantCulture);
            set => Display = Convert.ToDouble(value);
        }

        private double Memory
        {
            get => MemoryList.Count == 0 ? 0 : MemoryList[0].Value;
            set
            {
                if (MemoryList.Count == 0)
                {
                    MemoryList.Add(new ListItem(value));
                }
                else
                {
                    MemoryList[0].Value = value;
                }
            }
        }

        private void ApplyOperation()
        {
            _operand1 = _operand1 ?? Display;
            _operand2 = _operand2 ?? Display;

            switch (_operation)
            {
                case MathOperations.Plus:
                    Display = _operand1.Value + _operand2.Value;
                    break;
                case MathOperations.Minus:
                    Display = _operand1.Value - _operand2.Value;
                    break;
                case MathOperations.Multiplication:
                    Display = _operand1.Value * _operand2.Value;
                    break;
                case MathOperations.Division:
                    Display = _operand1.Value / _operand2.Value;
                    break;
            }

            _operand1 = null;
        }

        private void ListItemDelete(ListItem listItem)
        {
            if (HistoryList.Contains(listItem))
            {
                HistoryList.Remove(listItem);
                return;
            }

            if (MemoryList.Contains(listItem))
            {
                MemoryList.Remove(listItem);
            }
        }

        private void Input(MathOperations mathOperation)
        {
            if(mathOperation == MathOperations.MemoryRead)
            {
                Display = Memory;
                _operation = MathOperations.MemoryRead;
                _operand1 = null;
                return;
            }

            if(mathOperation == MathOperations.MemoryPlus)
            {
                Memory += Display;
                _operation = MathOperations.MemoryPlus;
                return;
            }

            if(mathOperation == MathOperations.MemoryMinus)
            {
                Memory -= Display;
                _operation = MathOperations.MemoryMinus;
                return;
            }

            if (mathOperation == MathOperations.MemorySet)
            {
                MemoryList.Insert(0, new ListItem(Display));
                _operation = MathOperations.MemorySet;
                return;
            }

            if(mathOperation == MathOperations.MemoryClear)
            {
                MemoryList.Clear();
                return;
            }

            if (mathOperation == MathOperations.Plus || mathOperation == MathOperations.Minus || mathOperation == MathOperations.Multiplication || mathOperation == MathOperations.Division)
            {
                if (_operand1.HasValue)
                    ApplyOperation();

                _operation = mathOperation;
                _operand2 = null;
                return;
            }

            if (mathOperation == MathOperations.Equal)
            {
                ApplyOperation();
                HistoryList.Insert(0, new ListItem(Display));
                if(_operation == null)
                    _operation = MathOperations.Equal;
                return;
            }

            if (_operation == MathOperations.Equal || _operation == MathOperations.MemorySet)  //Второе Слагаемое Вводится После Ввода Нуля 
            {
                _operation = null;
                DisplayText = ((int)mathOperation).ToString();
                return;
            }

            if (_operation.HasValue && _operand1 == null)
            {
                _operand1 = Display;
                Display = 0;
            }

            if (_operand1.HasValue && _operand2.HasValue)
            {
                _operation = null;
                _operand1 = null;
                _operand2 = null;
            }

            if (DisplayText == "0")
            {
                DisplayText = ((int)mathOperation).ToString();
                return;
            }


            DisplayText += ((int)mathOperation).ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}