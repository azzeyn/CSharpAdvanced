using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public class UserRegistrationValidator:IFieldValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_Length = 100;
        const int LastName_Min_Length = 2;
        const int LastName_Max_Length = 100;

        delegate bool EmailExistDel(string emailAddress);

        FieldValidatorDel _fieldValidatorDel = null;

        RequiredValidDel _requiredValidDel = null;
        StringLengValidDel _stringLengValidDel = null;
        DateValidDel _dateValidDel = null;
        PatternMatchValidDel _patternMatchValidDel = null;
        CompareFieldsValidDel _compareFieldsValidDel = null;

        EmailExistDel _emailExistDel = null;

        string[] _fieldArray = null;

        public string[] FieldArray
        {
            get
            {
                if (_fieldArray == null)
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

        public void InitialiseValidatorDelegates()
        {
            _requiredValidDel = CommonFieldValidatorFunctions.RequiredValidDel;
            _stringLengValidDel = CommonFieldValidatorFunctions.StringLengValidDel;
            _dateValidDel = CommonFieldValidatorFunctions.DateValidDel;
            _patternMatchValidDel= CommonFieldValidatorFunctions.PatternMatchValidDel;
            _compareFieldsValidDel= CommonFieldValidatorFunctions.CompareFieldsValidDel;
        }
    }
}
