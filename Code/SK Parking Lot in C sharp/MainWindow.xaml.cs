using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SK_Parking_Lot_in_C_sharp {
    /// <summary>
    /// TODO
    /// </summary>

    [Serializable()]
    public partial class MainWindow : Window, ISerializable {

        private static long parkingID_Initializer = 412534L;
        private static long memberID_Initializer = 641235L;
        private static long entryCounter = 0;
        private static int numberOfSpots = 200;

        private bool[] parkingSpots;

        [Serializable()]
        private class allPrice : ISerializable {
            public DateTime _date;
            public int _price;

            public allPrice(int price) {
                _date = DateTime.Now.Date;
                _price = price;
            }
            public allPrice(SerializationInfo info, StreamingContext ctxt) {
                _date = (DateTime)info.GetValue("allPrice_date", typeof(DateTime));
                _price = (int)info.GetValue("allPrice_price", typeof(int));
            }
            public void GetObjectData(SerializationInfo info, StreamingContext ctxt) {
                info.AddValue("allPrice_date", _date);
                info.AddValue("allPrice_price", _price);
            }

        };

        private List<allPrice> priceStorage;

        [Serializable()]
        private class CustomerCar : ISerializable {

            public long parkingID;
            public string carRegistrationNumber;
            public string carDescription;
            public int parkingSpot;
            public DateTime startTime;

            public CustomerCar(long param_parkingID, string param_CarRegistrationNumber,
                string param_carDescription, int param_parkingSpot) {

                this.parkingID = param_parkingID;
                this.carRegistrationNumber = param_CarRegistrationNumber;
                this.carDescription = param_carDescription;
                this.parkingSpot = param_parkingSpot;
                this.startTime = DateTime.Now;
            }
            public CustomerCar(SerializationInfo info, StreamingContext ctxt) {
                parkingID = (long)info.GetValue("CustomerCar_parkingID", typeof(long));
                carRegistrationNumber = String.Copy((string)info.GetValue("CustomerCar_carRegistrationNumber", typeof(string)));
                carDescription = String.Copy((string)info.GetValue("CustomerCar_carDescription", typeof(string)));
                parkingSpot = (int)info.GetValue("CustomerCar_parkingSpot", typeof(int));
                startTime = (DateTime)info.GetValue("CustomerCar_startTime", typeof(DateTime));
            }
            public void GetObjectData(SerializationInfo info, StreamingContext ctxt) {
                info.AddValue("CustomerCar_parkingID", parkingID);
                info.AddValue("CustomerCar_carRegistrationNumber", carRegistrationNumber);
                info.AddValue("CustomerCar_carDescription", carDescription);
                info.AddValue("CustomerCar_parkingSpot", parkingSpot);
                info.AddValue("CustomerCar_startTime", startTime);
            }
            public string To_String() {
                string s = String.Format("{0,8} | {1,15} | {2,17} | {3,7} |\r\n", this.parkingID, this.carRegistrationNumber,
                this.carDescription, this.parkingSpot);
                return s;
            }
        }

        [Serializable()]
        private class Member : ISerializable {

            public string customerName;
            public long ssn;
            public long phone;
            public long memberID;
            public DateTime startdate;
            public DateTime enddate;
            public int hoursPerday;


            public Member(string param_customerName, long param_ssn,
                long param_phone, long param_memberID, int param_Monthvalidity, int param_hoursPerday) {

                this.customerName = param_customerName;
                this.ssn = param_ssn;
                this.phone = param_phone;
                this.memberID = param_memberID;
                this.startdate = DateTime.Now;
                this.enddate = DateTime.Now.AddMonths(param_Monthvalidity);
                this.hoursPerday = param_hoursPerday;

            }
            public Member(SerializationInfo info, StreamingContext ctxt) {
                customerName = String.Copy((string)info.GetValue("Member_customerName", typeof(string)));
                ssn = (long)info.GetValue("Member_ssn", typeof(long));
                phone = (long)info.GetValue("Member_phone", typeof(long));
                memberID = (long)info.GetValue("Member_memberID", typeof(long));
                startdate = (DateTime)info.GetValue("Member_startdate", typeof(DateTime));
                enddate = (DateTime)info.GetValue("Member_enddate", typeof(DateTime));
                hoursPerday = (int)info.GetValue("Member_hoursPerday", typeof(int));
            }
            public void GetObjectData(SerializationInfo info, StreamingContext ctxt) {
                info.AddValue("Member_customerName", customerName);
                info.AddValue("Member_ssn", ssn);
                info.AddValue("Member_phone", phone);
                info.AddValue("Member_memberID", memberID);
                info.AddValue("Member_startdate", startdate);
                info.AddValue("Member_enddate", enddate);
                info.AddValue("Member_hoursPerday", hoursPerday);
            }

            public bool isValid() {
                DateTime currentDate = DateTime.Now;
                if (enddate > currentDate) {
                    return true;
                } else {
                    return false;
                }

            }

            public string To_String() {
                string s = String.Format("{0,8} | {1,20} | {2,12} | {3,12}|\r\n", this.memberID,
                this.customerName, this.ssn, this.phone);

                return s;
            }

            public string TodetailedString() {
                string s = ("\r\nMember ID : " + this.memberID
                    + "\r\nName : " + this.customerName
                    + "\r\nSSN : " + this.ssn
                    + "\r\nPhone :" + this.phone
                    + "\r\nStart Date : " + this.startdate.ToShortDateString()
                    + "\r\nValidity upto : " + this.enddate.ToShortDateString()
                    + "\r\nHours per day : " + this.hoursPerday);
                return s;
            }
        }

        [Serializable()]
        private class MemberCar : ISerializable {

            public long parkingID;
            public long memberID;
            public string carDescription;
            public int parkingSpot;
            public DateTime start;

            public MemberCar(long param_parkingID, long param_memberID,
                string param_carDescription, int param_parkingSpot) {

                this.parkingID = param_parkingID;
                this.memberID = param_memberID;
                this.carDescription = param_carDescription;
                this.parkingSpot = param_parkingSpot;
                this.start = DateTime.Now;
            }
            public MemberCar(SerializationInfo info, StreamingContext ctxt) {
                parkingID = (long)info.GetValue("MemberCar_parkingID", typeof(long));
                memberID = (long)info.GetValue("MemberCar_memberID", typeof(long));
                carDescription = String.Copy((string)info.GetValue("MemberCar_carDescription", typeof(string)));
                parkingSpot = (int)info.GetValue("MemberCar_parkingSpot", typeof(int));
                start = (DateTime)info.GetValue("MemberCar_startTime", typeof(DateTime));
            }
            public void GetObjectData(SerializationInfo info, StreamingContext ctxt) {
                info.AddValue("MemberCar_parkingID", parkingID);
                info.AddValue("MemberCar_memberID", memberID);
                info.AddValue("MemberCar_carDescription", carDescription);
                info.AddValue("MemberCar_parkingSpot", parkingSpot);
                info.AddValue("MemberCar_startTime", start);
            }
            public string To_String() {
                string s = String.Format("{0,8} | {1,10} | {2,20} | {3,12} |\r\n", this.parkingID, this.memberID,
                this.carDescription, this.parkingSpot);
                return s;
            }
        }

        private List<CustomerCar> CustomerCars;
        private List<MemberCar> MemberCars;
        private List<Member> Members;

        public MainWindow() {
            InitializeComponent();

            MessageBoxResult result = MessageBox.Show(("Please confirm that current date is " + DateTime.Now.ToShortDateString()
                + ". \r\n[ If date is incorrect click cancel to stop the application; and restart it after correcting system date."
                + " Incorrect date could cause data corruption. ]"),"Warning",MessageBoxButton.OKCancel);
            if(result == MessageBoxResult.Cancel) {
                Environment.Exit(0);
            }

            if (!loadAlldata("savedData.dat")) {
                parkingSpots = new bool[numberOfSpots];
                CustomerCars = new List<CustomerCar>();
                MemberCars = new List<MemberCar>();
                Members = new List<Member>();
                priceStorage = new List<allPrice>();

            }
            updateAllMemberTable();
            updateCustomerTable();
            updateMemberCarTable();
        }
        public MainWindow(SerializationInfo info, StreamingContext ctxt) {
            CustomerCars = (List<CustomerCar>)info.GetValue("MainWindow_CustomerCars", typeof(List<CustomerCar>));
            MemberCars = (List<MemberCar>)info.GetValue("MainWindow_MemberCars", typeof(List<MemberCar>));
            Members = (List<Member>)info.GetValue("MainWindow_Members", typeof(List<Member>));
            priceStorage = (List<allPrice>)info.GetValue("MainWindow_priceStorage", typeof(List<allPrice>));
            parkingID_Initializer = (long)info.GetValue("MainWindow_parkingID_Initializer", typeof(long));
            memberID_Initializer = (long)info.GetValue("MainWindow_memberID_Initializer", typeof(long));
            entryCounter = (long)info.GetValue("MainWindow_entryCounter", typeof(long));
            parkingSpots = (bool[])info.GetValue("MainWindow_parkingSpots", typeof(bool[]));

        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt) {
            info.AddValue("MainWindow_CustomerCars", CustomerCars);
            info.AddValue("MainWindow_MemberCars", MemberCars);
            info.AddValue("MainWindow_Members", Members);
            info.AddValue("MainWindow_priceStorage", priceStorage);
            info.AddValue("MainWindow_parkingID_Initializer", parkingID_Initializer);
            info.AddValue("MainWindow_memberID_Initializer", memberID_Initializer);
            info.AddValue("MainWindow_entryCounter", entryCounter);
            info.AddValue("MainWindow_parkingSpots", parkingSpots);

        }

        private bool saveAlldata(string fileName) {

            if (File.Exists(fileName)) {
                try {
                    File.Copy(fileName, (fileName + ".BAK"), true);
                    File.Delete(fileName);
                } catch {
                    // Ignore
                }

            }
            Stream s = null;
            try {
                s = File.Open(fileName, FileMode.OpenOrCreate);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, CustomerCars);
                b.Serialize(s, MemberCars);
                b.Serialize(s, Members);
                b.Serialize(s, priceStorage);
                b.Serialize(s, parkingID_Initializer);
                b.Serialize(s, memberID_Initializer);
                b.Serialize(s, entryCounter);
                b.Serialize(s, parkingSpots);
            } catch (Exception) {
                s.Close();
                return false;

            } finally {
                s.Close();
            }
            return true;
        }

        private bool loadAlldata(string fileName) {
            try {
                Stream s = File.Open(fileName, FileMode.Open);
                BinaryFormatter b = new BinaryFormatter();
                CustomerCars = (List<CustomerCar>)b.Deserialize(s);
                MemberCars = (List<MemberCar>)b.Deserialize(s);
                Members = (List<Member>)b.Deserialize(s);
                priceStorage = (List<allPrice>)b.Deserialize(s);
                parkingID_Initializer = (long)b.Deserialize(s);
                memberID_Initializer = (long)b.Deserialize(s);
                entryCounter = (long)b.Deserialize(s);
                parkingSpots = (bool[])b.Deserialize(s);
                s.Close();
            } catch (Exception) {
                return false;
            }
            return true;
        }
        private int validateMemberID(long MemberID) {

            int countOfMembers = Members.Count;
            for (int i = 0; i < countOfMembers; i++) {
                if (MemberID == Members[i].memberID) {
                    if (Members[i].isValid()) {
                        return 1;
                    } else {
                        return 0;
                    }
                }
            }
            return -1;
        }

        private bool addCustomerCar() {
            string param_CarRegistrationNumber;
            string param_carDescription;
            int param_parkingSpot;


            try {
                param_CarRegistrationNumber = Tab1TextboxCarNumberAdd.Text;
                param_carDescription = Tab1TextboxCarDescription.Text;

                if (string.IsNullOrEmpty(param_carDescription) ||
                    string.IsNullOrEmpty(param_CarRegistrationNumber)) {
                    setStatus_tab1Customer("Error : Invalid Input");
                    return false;
                }

                param_parkingSpot = getEmptySpot();
                if (param_parkingSpot == -1) {
                    setStatus_tab1Customer("Sorry! No Empty Parking Spot.");
                    return false;
                }
            } catch (Exception) {
                setStatus_tab1Customer("Error : Invalid Input");
                return false;
            }


            CustomerCars.Add(new CustomerCar(parkingID_Initializer, param_CarRegistrationNumber,
                param_carDescription, param_parkingSpot));


            string status = ("Entry permission granted! \r\n Parking ID : "
                + parkingID_Initializer + ", Parking Spot : " + param_parkingSpot);

            setStatus_tab1Customer(status);

            parkingID_Initializer++;
            this.parkingSpots[param_parkingSpot] = true;
            entryCounter++;

            return true;
        }

        private bool addMemberCar() {
            long param_memberID;
            string param_carDescription;
            int param_parkingSpot;


            try {
                param_memberID = long.Parse(Tab2TextboxMemberIDAdd.Text);
                param_carDescription = Tab2TextboxCarDescription.Text;

                if (string.IsNullOrEmpty(param_carDescription)) {
                    setStatus_tab2MemberCar("Error : Car description is empty");
                    return false;
                }

                param_parkingSpot = getEmptySpot();
                if (param_parkingSpot == -1) {
                    setStatus_tab2MemberCar("Sorry! No Empty Parking Spot.");
                    return false;
                }
            } catch (Exception) {
                setStatus_tab2MemberCar("Error : Invalid Input");
                return false;
            }

            int validityFlag = this.validateMemberID(param_memberID);
            if (validityFlag == 0) {
                setStatus_tab2MemberCar("Your validity is expired. Please renew it.");
                return false;
            }
            if (validityFlag == -1) {
                setStatus_tab2MemberCar("Invalid Member ID");
                return false;
            }

            foreach (MemberCar temp in MemberCars) {
                if (temp.memberID == param_memberID) {
                    setStatus_tab2MemberCar("ERROR : Car of the provided member ID is already in." +
                        "\r\n Cannot add two cars with same member ID" +
                        "\r\n Use service for non-members to enter another car in parking lot.");
                    return false;
                }
            }

            MemberCars.Add(new MemberCar(parkingID_Initializer, param_memberID, param_carDescription,
                param_parkingSpot));

            string status = ("Entry permission granted! \r\n Parking ID : "
                + parkingID_Initializer + ", Parking Spot : " + param_parkingSpot);

            setStatus_tab2MemberCar(status);

            parkingID_Initializer++;
            this.parkingSpots[param_parkingSpot] = true;
            entryCounter++;
            return true;

        }

        private bool addMember() {
            string param_customerName;
            long param_ssn;
            long param_phone;
            int param_Monthvalidity;
            int param_hoursPerday;


            try {
                param_customerName = tab3textboxName.Text;
                param_ssn = long.Parse(tab3textboxSSN.Text);
                param_phone = long.Parse(tab3textboxPhone.Text);
                param_Monthvalidity = int.Parse(tab3textboxMonths.Text);
                param_hoursPerday = int.Parse(tab3textboxhours.Text);

                if (string.IsNullOrEmpty(param_customerName)) {
                    setStatus_tab3Members("Error : Invalid Input");
                    return false;
                }

                if (param_hoursPerday < 1 || param_hoursPerday > 23) {
                    setStatus_tab3Members("Error : Invalid Input \r\n Hours per day should be an integer between 0 and 24.");
                    return false;
                }
                if (param_Monthvalidity < 1) {
                    setStatus_tab3Members("Error: months should be greater than 0");
                    return false;
                }
                if (param_ssn < 1) {
                    setStatus_tab3Members("Error: Invalid SSN detail");
                    return false;
                }
                if (param_phone < 1 ) {
                    setStatus_tab3Members("Error: Invalid Phone detail");
                    return false;
                }

            } catch (Exception) {
                setStatus_tab3Members("Error : Invalid Input");
                return false;
            }

            int price = MemberPriceCalculator(param_Monthvalidity, param_hoursPerday);

            Members.Add(new Member(param_customerName, param_ssn,
                param_phone, memberID_Initializer, param_Monthvalidity, param_hoursPerday));

            string status = ("Member Added! \r\n Member ID : " + memberID_Initializer
                            + ", Validity upto : " + (DateTime.Now.AddMonths(param_Monthvalidity)).ToShortDateString()
                            + "\r\n Membership price : " + price);

            setStatus_tab3Members(status);

            priceStorage.Add(new allPrice(price));
            memberID_Initializer++;


            return true;

        }

        private int getEmptySpot() {
            
            for (int i = 5; i < numberOfSpots; i++) {
                if (parkingSpots[i] == false) {  // is empty
                    return i;
                }
            }
            return -1;
        }

        private bool displayCurrentCustomerPrice() {

            long param_parkingID;

            try {
                param_parkingID = long.Parse(Tab1TextboxCarNumberPrice.Text);
            } catch (Exception) {
                setStatus_tab1Customer("Error : Invalid Parking ID");
                return false;
            }
            int index = getCustomerCar_listIndex(param_parkingID);
            if (index == -1) {
                setStatus_tab1Customer("Error : Invalid Non-member Parking ID");
                return false;
            }
            DateTime d1 = CustomerCars[index].startTime;
            int price = CustomerPriceCalculator(d1, DateTime.Now);

            string status = ("Current fare for Parking ID : " + param_parkingID
                            + " is " + price);

            setStatus_tab1Customer(status);

            return true;

        }
        private void setStatus_tab1Customer(string s) {

            Tab1TextboxStatus.AppendText("\r\n__________________________________________________\r\n");
            Tab1TextboxStatus.AppendText(s + "\r\n");
            Tab1TextboxStatus.ScrollToEnd();
        }

        private void setStatus_tab2MemberCar(string s) {

            Tab2TextboxStatus.AppendText("\r\n__________________________________________________\r\n");
            Tab2TextboxStatus.AppendText(s + "\r\n");
            Tab2TextboxStatus.ScrollToEnd();
        }
        private void setStatus_tab3Members(string s) {

            Tab3TextboxStatus.AppendText("\r\n__________________________________________________\r\n");
            Tab3TextboxStatus.AppendText(s + "\r\n");
            Tab3TextboxStatus.ScrollToEnd();
        }

        public int MemberPriceCalculator(int months, int hoursPerday) {
            return (10 * months * 30 * hoursPerday);
        }

        public int CustomerPriceCalculator(DateTime start, DateTime end) {

            TimeSpan difference = end - start;
            int hourdiff = (int)(difference.TotalHours + 1);
            return (20 * hourdiff);

        }

        private bool removeCustomerCar() {

            long param_parkingID;

            try {
                param_parkingID = long.Parse(Tab1TextboxCarNumberPrice.Text);
            } catch (Exception) {
                setStatus_tab1Customer("Error : Invalid Parking ID ");
                return false;
            }
            int index = getCustomerCar_listIndex(param_parkingID);
            if (index == -1) {
                setStatus_tab1Customer("Error : Parking ID not found");
                return false;
            }

            CustomerCar temp = CustomerCars[index]; // reference

            parkingSpots[temp.parkingSpot] = false;
            int price = CustomerPriceCalculator(temp.startTime, DateTime.Now);
            CustomerCars.RemoveAt(index);

            priceStorage.Add(new allPrice(price));

            setStatus_tab1Customer("Car Entry Removed! \r\n Fare for " + param_parkingID +
                " is Rs " + price);

            return true;
        }

        private bool removeMemberCar() {

            long param_parkingID;

            try {
                param_parkingID = long.Parse(Tab2TextboxCarNumberRemove.Text);
            } catch (Exception) {
                setStatus_tab2MemberCar("Error : Invalid Parking ID ");
                return false;
            }
            int indexCar = getMemberCar_listIndex(param_parkingID);
            if (indexCar == -1) {
                setStatus_tab2MemberCar("Error : Parking ID not found");
                return false;
            }

            MemberCar temp = MemberCars[indexCar];  // rreference

            parkingSpots[temp.parkingSpot] = false;
            int duration = (int)(((TimeSpan)(DateTime.Now - temp.start)).TotalHours);

            bool statusflag = false;
            if (duration > Members[getMember_listIndex(temp.memberID)].hoursPerday) {
                statusflag = true;
            }
            MemberCars.RemoveAt(indexCar);

            if (statusflag == true) {
                setStatus_tab2MemberCar("WARNING : Exceeded Daily hour Limit.\r\n Car Entry Removed!");
            } else {
                setStatus_tab2MemberCar("Car Entry Removed!");
            }

            return true;
        }

        private bool removeMember() {
            long param_memberID;

            try {
                param_memberID = long.Parse(tab3textboxMemberIDremove.Text);
            } catch (Exception) {
                setStatus_tab3Members("Error : Invalid Member ID ");
                return false;
            }
            int index = getMember_listIndex(param_memberID);
            if (index == -1) {
                setStatus_tab3Members("Error : Member Not Found");
                return false;
            }

            Member temp = Members[index];   // reference
            int price = 0;
            if (temp.enddate.Date > DateTime.Now.Date) {
                TimeSpan difference = (temp.enddate - DateTime.Now);
                price = MemberPriceCalculator(((int)(difference.TotalDays / 30)), temp.hoursPerday);
                price = price - 200;  // Panalty
            }

            Members.RemoveAt(index);
            priceStorage.Add(new allPrice((-1)*price));
            setStatus_tab3Members(" Member with ID : " + param_memberID + " is removed successfully."
                + "\r\n Price to be returned = Rs" + price);

            return true;
        }

        private bool increaseValidity() {
            long param_memberID;
            int param_validity;

            try {
                param_memberID = long.Parse(tab3textboxMemberIDvalidity.Text);
                param_validity = int.Parse(tab3textboxMonthsincrease.Text);
            } catch (Exception) {
                setStatus_tab3Members("Error : Invalid Input ");
                return false;
            }

            int index = getMember_listIndex(param_memberID);
            if (index == -1) {
                setStatus_tab3Members("Error : Member Not Found");
                return false;
            }
            Member temp = Members[index]; // reference

            if (param_validity < 1) {
                TimeSpan difference = (temp.enddate - DateTime.Now);
                if ((int)((difference.TotalDays) / 30) <= (-1)*param_validity) {
                    setStatus_tab3Members("Error : Cannot decrease validity to date before today");
                    return false;

                }
            }
               
            DateTime newDate = temp.enddate;
            if (newDate < DateTime.Now) {
                temp.enddate = DateTime.Now.AddMonths(param_validity);
            } else {
                temp.enddate = newDate.AddMonths(param_validity);
            }

            int price = MemberPriceCalculator(param_validity, temp.hoursPerday);
            priceStorage.Add(new allPrice(price));

            setStatus_tab3Members("Membership of " + temp.memberID
                + " is now valid upto " + temp.enddate.ToShortDateString()
                + "\r\n Additional Fare : Rs " + price);

            return true;
        }

        private bool increaseHours() {
            long param_memberID;
            int param_hours;

            try {
                param_memberID = long.Parse(tab3textboxMemberIDvalidity.Text);
                param_hours = int.Parse(tab3textboxhoursmanipulate.Text);
            } catch (Exception) {
                setStatus_tab3Members("Error : Invalid Input ");
                return false;
            }
            if (param_hours < 1 || param_hours > 23) {
                setStatus_tab3Members("Hours per day should be a integer between 0 and 24");
                return false;
            }
            int index = getMember_listIndex(param_memberID);
            if (index == -1) {
                setStatus_tab3Members("Error : Member Not Found");
                return false;
            }
            Member temp = Members[index];  // reference

            TimeSpan validity = temp.enddate - temp.startdate;
            if (validity.TotalDays < 0) {
                setStatus_tab3Members("Cannot manipulate, Validity Expired!");
                return false;
            }
            int hourdifference = param_hours - temp.hoursPerday;

            int price = (((int)(validity.TotalDays) / 30) * MemberPriceCalculator(1, hourdifference));
            temp.hoursPerday = param_hours;

            priceStorage.Add(new allPrice(price));

            setStatus_tab3Members("Hours per day of Member " + temp.memberID
                + " now = " + param_hours + "\r\nAdditional price : " + price);

            return true;
        }

        private void displayMemberInfo() {
            long param_memberID;

            try {
                param_memberID = long.Parse(tab3textboxMemberIDsearch.Text);
            } catch (Exception) {
                setStatus_tab3Members("Error : Invalid Member ID ");
                return;
            }

            int index = getMember_listIndex(param_memberID);
            if (index == -1) {
                setStatus_tab3Members("Error : Member Not Found");
                return;
            }

            string m_output = ("Member Details--------" + Members[index].TodetailedString());
            setStatus_tab3Members(m_output);

        }

        private int getAllPrice(DateTime param_date) {
            int local_price = 0;
            foreach (allPrice temp in priceStorage) {
                if (param_date.Date == temp._date.Date) {
                    local_price += temp._price;
                }
            }
            return local_price;
        }

        private int getAllPrice(DateTime param_date1, DateTime param_date2) {
            int local_price = 0;
            foreach (allPrice temp in priceStorage) {
                if (temp._date.Date >= param_date1.Date && temp._date.Date <= param_date2.Date) {
                    local_price += temp._price;
                }
            }
            return local_price;
        }

        private string displayFreeParkingSpots() {
            StringBuilder s = new StringBuilder();
            for (int i = 6; i < numberOfSpots; i++) {
                if (parkingSpots[i] == false) {
                    s.Append(i + " ");
                }
            }
            return s.ToString();
        }
        private string displayOccupiedParkingSpots() {
            StringBuilder s = new StringBuilder();
            for (int i = 6; i < numberOfSpots; i++) {
                if (parkingSpots[i] == true) {
                    s.Append(i + " ");
                }
            }
            return s.ToString();

        }

        private void updateCustomerTable() {
            Tab1TextboxCarList.Clear();
            Tab1TextboxCarList.Text = String.Format("{0,8} | {1,15} | {2,17} | {3,7} |\r\n", "PRKNG ID", "CAR REG. NO.",
                "CAR DESCRIPTION", "SPOT");
            if (CustomerCars == null) {
                return;
            }
            foreach (CustomerCar temp in CustomerCars) {
                Tab1TextboxCarList.AppendText(temp.To_String());
            }
        }
        private void updateAllMemberTable() {
            Tab4TextboxMemberList.Clear();
            Tab4TextboxMemberList.Text = String.Format("{0,8} | {1,20} | {2,12} | {3,12}|\r\n", "MMBR ID",
                "NAME", "SSN", "PHONE");
            if (Members == null) {
                return;
            }
            foreach (Member temp in Members) {
                Tab4TextboxMemberList.AppendText(temp.To_String());
            }
        }
        private void updateValidMemberTable() {
            Tab4TextboxMemberList.Clear();
            Tab4TextboxMemberList.Text = String.Format("{0,8} | {1,20} | {2,12} | {3,12}|\r\n", "MMBR ID",
                "NAME", "SSN", "PHONE");
            if (Members == null) {
                return;
            }
            foreach (Member temp in Members) {
                if (temp.isValid()) {
                    Tab4TextboxMemberList.AppendText(temp.To_String());
                }
            }
        }
        private void updateInValidMemberTable() {
            Tab4TextboxMemberList.Clear();
            Tab4TextboxMemberList.Text = String.Format("{0,8} | {1,20} | {2,12} | {3,12}|\r\n", "MMBR ID",
                "NAME", "SSN", "PHONE");
            if (Members == null) {
                return;
            }
            foreach (Member temp in Members) {
                if (!temp.isValid()) {
                    Tab4TextboxMemberList.AppendText(temp.To_String());
                }
            }
        }

        private void updateMemberCarTable() {
            Tab2TextboxCarList.Clear();
            Tab2TextboxCarList.Text = String.Format("{0,8} | {1,10} | {2,20} | {3,12} |\r\n", "PRKNG ID", "MEMBER ID",
                "CAR DESCRIPTION", "SPOT");
            if (MemberCars == null) {
                return;
            }
            foreach (MemberCar temp in MemberCars) {
                Tab2TextboxCarList.AppendText(temp.To_String());
            }
        }



        private int getCustomerCar_listIndex(long param_parkingID) {
            int i = -1;
            foreach (CustomerCar temp in CustomerCars) {
                i++;
                if (temp.parkingID == param_parkingID) {
                    return i;
                }
            }
            return -1;
        }
        private int getMemberCar_listIndex(long param_parkingID) {
            int i = -1;
            foreach (MemberCar temp in MemberCars) {
                i++;
                if (temp.parkingID == param_parkingID) {
                    return i;
                }
            }
            return -1;
        }

        private int getMember_listIndex(long param_memberID) {
            int i = -1;
            foreach (Member temp in Members) {
                i++;
                if (temp.memberID == param_memberID) {
                    return i;
                }
            }
            return -1;
        }

        private void Tab1ButtonAdd_Click(object sender, RoutedEventArgs e) {
            addCustomerCar();
            if ((bool)tab1checkboxupdate.IsChecked) {
                updateCustomerTable();
            }

        }

        private void Tab1ButtonFare_Click(object sender, RoutedEventArgs e) {
            displayCurrentCustomerPrice();
        }

        private void Tab1ButtonRemove_Click(object sender, RoutedEventArgs e) {
            removeCustomerCar();
            if ((bool)tab1checkboxupdate.IsChecked) {
                updateCustomerTable();
            }
        }

        private void Tab2ButtonAdd_Click(object sender, RoutedEventArgs e) {
            addMemberCar();
            if ((bool)tab2checkboxupdate.IsChecked) {
                updateMemberCarTable();
            }
        }

        private void Tab2ButtonRemove_Click(object sender, RoutedEventArgs e) {
            removeMemberCar();
            if ((bool)tab2checkboxupdate.IsChecked) {
                updateMemberCarTable();
            }
        }

        private void tab3buttonAdd_Click(object sender, RoutedEventArgs e) {
            addMember();
            tab4comboboxMemberSelector.SelectedIndex = 0;
            updateAllMemberTable();

        }

        private void tab3buttonSearch_Click(object sender, RoutedEventArgs e) {
            displayMemberInfo();
        }

        private void tab3buttonRemove_Click(object sender, RoutedEventArgs e) {
            removeMember();
            tab4comboboxMemberSelector.SelectedIndex = 0;
            updateAllMemberTable();
        }

        private void tab3buttonsubmit_Click(object sender, RoutedEventArgs e) {
            increaseValidity();
        }

        private void tab3buttonsubmit_Copy_Click(object sender, RoutedEventArgs e) {
            increaseHours();
        }

        private void tab4ButtonRefresh_Click(object sender, RoutedEventArgs e) {
            if (tab4comboboxMemberSelector.SelectedItem == ComboBoxitemAllMembers) {
                updateAllMemberTable();
                return;
            }
            if (tab4comboboxMemberSelector.SelectedItem == ComboBoxitemValidMembers) {
                updateValidMemberTable();
                return;
            }
            if (tab4comboboxMemberSelector.SelectedItem == ComboBoxitemExpiredMembers) {
                updateInValidMemberTable();
                return;
            }
        }

        private void tab4buttonPrice_Click(object sender, RoutedEventArgs e) {

            if ((bool)tab4radioPriceOn.IsChecked) {

                if (!datepick1day.SelectedDate.HasValue) {
                    return;
                }

                DateTime date1 = ((DateTime)datepick1day.SelectedDate).Date;
                int pr = getAllPrice(date1);
                MessageBox.Show(("Total amount on " + date1.Date.ToShortDateString() + " is "
                    + pr), "Total Amount", MessageBoxButton.OK);
                return;
            }
            if ((bool)tab4radioPricebetween.IsChecked) {

                if ((!datepickbetween1.SelectedDate.HasValue) || (!datepickbetween2.SelectedDate.HasValue)) {
                    return;
                }

                DateTime date1 = ((DateTime)datepickbetween1.SelectedDate).Date;
                DateTime date2 = ((DateTime)datepickbetween2.SelectedDate).Date;
                int pr = getAllPrice(date1, date2);
                MessageBox.Show(("Total amount from " + date1.Date.ToShortDateString() +
                    " to " + date2.Date.ToShortDateString() + " is "
                    + pr), "Total Amount", MessageBoxButton.OK);
                return;
            }
        }

        private void tab1buttonRefresh_Click(object sender, RoutedEventArgs e) {
            updateCustomerTable();
        }

        private void tab4comboboxMemberSelector_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (tab4comboboxMemberSelector.SelectedItem == ComboBoxitemAllMembers) {
                updateAllMemberTable();
                return;
            }
            if (tab4comboboxMemberSelector.SelectedItem == ComboBoxitemValidMembers) {
                updateValidMemberTable();
                return;
            }
            if (tab4comboboxMemberSelector.SelectedItem == ComboBoxitemExpiredMembers) {
                updateInValidMemberTable();
                return;
            }
        }

        private void tab4buttoncount_Click(object sender, RoutedEventArgs e) {
            if ((bool)tab4radioallcustomers.IsChecked) {
                MessageBox.Show(("Total entries (since beginning) : " + entryCounter), "Counter",
                    MessageBoxButton.OK);
                return;
            }
            if ((bool)tab4radioallmembers.IsChecked) {
                MessageBox.Show(("Total Members : " + Members.Count), "Counter",
                    MessageBoxButton.OK);
                return;
            }
            if ((bool)tab4radiocustomercars.IsChecked) {
                MessageBox.Show(("Total Customer Cars : " + CustomerCars.Count), "Counter",
                    MessageBoxButton.OK);
                return;
            }
            if ((bool)tab4radioMembercars.IsChecked) {
                MessageBox.Show(("Total Member Cars : " + MemberCars.Count), "Counter",
                    MessageBoxButton.OK);
                return;
            }

            if ((bool)tab4radioparkingspots.IsChecked) {
                MessageBox.Show(("Number of total parking spots  : " + parkingSpots.Length),
                    "Counter",
                    MessageBoxButton.OK);
                return;
            }
            if ((bool)tab4radioEmptySpots.IsChecked) {
                MessageBox.Show(("Empty Spots : " + displayFreeParkingSpots()),
                    "Empty Parking Spots",
                    MessageBoxButton.OK);
                return;
            }
            if ((bool)tab4radioFilledSpots.IsChecked) {
                MessageBox.Show(("Filled Spots : " + displayOccupiedParkingSpots()),
                    "Occupied Parking Spots",
                    MessageBoxButton.OK);
                return;
            }

        }

        private void buttonInfo_Click(object sender, RoutedEventArgs e) {

            string s = ("SK PARKING LOT PROGRAM \r\n"
                + "Version - 2.4\r\n"
                + "Size (LOC) : 1307\r\n"
                + "\r\nDeveloper : Shubham Kumar\r\n"
                + "Email : shubham.kumar.sci@gmail.com");

            MessageBox.Show(s, "About", MessageBoxButton.OK);
            return;
        }


        private void tab2buttonRefresh_Click(object sender, RoutedEventArgs e) {
            updateMemberCarTable();
        }

        private void buttonSerialize_Click(object sender, RoutedEventArgs e) {
            saveAlldata("savedData.dat");
            MessageBox.Show("Saving Complete", "Save", MessageBoxButton.OK);
        }

        private void buttonDeserialize_Click(object sender, RoutedEventArgs e) {
            loadAlldata("savedData.dat");
        }
        private void DataWindow_closing(object sender, CancelEventArgs e) {
            saveAlldata("savedData.dat");
            return;
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e) {
            string s = ("Do you really want to reset ?\r\n"
                    + "This will delete all data including current session.\r\n");

            MessageBoxResult r = MessageBox.Show(s, "Warning!", MessageBoxButton.YesNo);

            if (r == MessageBoxResult.Yes) {
                if (File.Exists("savedData.dat")) {
                    try {
                        File.Delete("savedData.dat");
                    } catch {

                    }
                }
                if (File.Exists("savedData.dat.BAK")) {
                    try {
                        File.Delete("savedData.dat.BAK");
                    } catch {

                    }
                }
                MessageBox.Show("Reset Complete!\r\nApplication will now exit.\r\nPlease restart the application.", "Notice", MessageBoxButton.OK);
                Environment.Exit(0);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string fileName = "Exported_Data.txt";
            bool doneFlag = false;
            if (File.Exists(fileName)) {
                try {
                    File.Delete(fileName);
                } catch (Exception) { }
            }
            try {
                StringBuilder s = new StringBuilder(500);
                s.Append("_______________________________________________________________\r\n");
                s.Append("------------------- SK PARKING LOT SYSTEM ---------------------\r\n");
                s.Append("_______________________________________________________________\r\n\r\n");


                s.Append("This file is generated on " + DateTime.Now.ToString() + ".");

                s.Append("\r\n===============================================================\r\n");
                s.Append("\r\n\r\nMEMBER DETAILS ------------------------------------------------\r\n\r\n");
                s.Append(String.Format("{0,8} | {1,20} | {2,12} | {3,12}|\r\n", "MMBR ID",
                    "NAME", "SSN", "PHONE"));
                foreach (Member temp in Members) {
                    s.Append(temp.To_String());
                }
                s.Append("\r\nTotal number of Members = " + Members.Count);

                s.Append("\r\n===============================================================\r\n");
                s.Append("\r\n\r\nMEMBER CAR ENTRIES --------------------------------------------\r\n\r\n");
                s.Append(String.Format("{0,8} | {1,10} | {2,20} | {3,12} |\r\n", "PRKNG ID", "MEMBER ID",
                    "CAR DESCRIPTION", "SPOT"));
                foreach (MemberCar temp in MemberCars) {
                    s.Append(temp.To_String());
                }
                s.Append("\r\nTotal number of Member Cars = " + MemberCars.Count);

                s.Append("\r\n===============================================================\r\n");
                s.Append("\r\n\r\nNON-MEMBER CUSTOMER CAR ENTRIES -------------------------------\r\n\r\n");
                s.Append(String.Format("{0,8} | {1,15} | {2,17} | {3,7} |\r\n", "PRKNG ID", "CAR REG. NO.",
                    "CAR DESCRIPTION", "SPOT"));
                foreach (CustomerCar temp in CustomerCars) {
                    s.Append(temp.To_String());
                }
                s.Append("\r\nTotal number of Customer Cars = " + CustomerCars.Count);

                s.Append("\r\n===============================================================\r\n");
                s.Append("\r\nTotal number of Parking spots available : " + numberOfSpots);
                s.Append("\r\n\r\nOccupied Parking Spots : " + displayOccupiedParkingSpots());
                s.Append("\r\n\r\nUnoccupied Parking Spots : " + displayFreeParkingSpots());

                s.Append("\r\n===============================================================\r\n");
                s.Append("Generated by SK PARKING LOT Software\r\nVersion : 2.3");

                File.WriteAllText(fileName, s.ToString());
                doneFlag = true;
            } catch (Exception) {
                doneFlag = false;
                if (File.Exists(fileName)) {
                    try {
                        File.Delete(fileName);
                    } catch (Exception) { }
                }
            }

            if (doneFlag == true) {
                MessageBox.Show(("All data is exported to file \'" + fileName + "\' in the current directory of this program."),
                    "Data Export Successfull", MessageBoxButton.OK);
            } else {
                MessageBox.Show("Data export unsuccessful!\r\nPlease check whether you have rights to create files in current directory.",
                    "ERROR", MessageBoxButton.OK);

            }

        }

        
       

       
      

    }
}