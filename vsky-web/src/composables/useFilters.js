import { date } from "quasar";
import { notifyError } from "assets/utils";

export default function useFilters () {
  function toCurrency (value, precisons) {
    if (value !== undefined && value !== null) {
      const formatter = new Intl.NumberFormat("en-US", { style: "currency", currency: "USD", minimumFractionDigits: precisons, maximumFractionDigits: precisons });
      return formatter.format(value);
    }
    return value;
  }

  function toNumeric (value, precisons) {
    if (value !== undefined && value !== null) {
      const formatter = new Intl.NumberFormat("en-US", { minimumFractionDigits: precisons, maximumFractionDigits: precisons });
      return formatter.format(value);
    }
    return value;
  }

  function toPercentage (value, precisons) {
    if (value !== undefined && value !== null) {
      const formatter = new Intl.NumberFormat("en-US", { minimumFractionDigits: precisons, maximumFractionDigits: precisons });
      return formatter.format(value) + "%";
    }
    return value;
  }

  function onlyLetter ($event) {
    const char = String.fromCharCode($event.keyCode); // Get the character
    if (/^[A-Za-z ]+$/.test(char)) {
      return true; // Match with regex
    } else {
      $event.preventDefault(); // If not match, don"t add to input text
    }
  }

  function randomIntFromInterval (min, max) { // min and max included
    return Math.floor(Math.random() * (max - min + 1) + min);
  }

  function onlyNumber ($event) {
    const keyCode = ($event.keyCode ? $event.keyCode : $event.which);
    if ((keyCode < 48 || keyCode > 57) && keyCode !== 46) { // 46 is dot
      $event.preventDefault();
    }
  }

  function toPhone (value) {
    return value ? value.replace(/(\d{3})(\d{3})(\d{4})/, "($1)$2-$3") : "";
  }

  function toFax (value) {
    return value ? value.replace(/(\d{3})(\d{3})(\d{4})/, "($1)$2-$3") : "";
  }

  function toName (lastName, firstName, middleName) {
    const name = (lastName ?? "") + ", " + (firstName ?? "") + " " + (middleName ?? "");
    return name.trim();
  }

  function toDate (value, format) {
    return value ? date.formatDate(value, format || "MM/DD/YYYY") : "";
  }

  function toDateTime (value, format) {
    return value ? date.formatDate(value, format || "MM/DD/YYYY hh:mm A") : "";
  }

  function toTime (value, format) {
    return value ? date.formatDate(value, format || "hh:mm A") : "";
  }

  function truncate (value, length) {
    length = length || 15;
    if (!value || typeof value !== "string") return "";
    if (value.length <= length) return value;
    return value.substring(0, length) + "...";
  }

  function toLowercase (value) {
    return (value || value === 0) ? value.toString().toLowerCase() : "";
  }

  function toUpperCase (value) {
    return (value || value === 0) ? value.toString().toUpperCase() : "";
  }

  function calculateDayDiff (dateStr) {
    var date1 = new Date(dateStr);
    var date2 = new Date();
    var DifferenceInTime = date2.getTime() - date1.getTime();
    return DifferenceInTime / (1000 * 3600 * 24);
  }

  function addDaysinDate (dateStr, numberOfDaysToAdd) {
    var someDate = new Date(dateStr);
    var result = someDate.setDate(someDate.getDate() + numberOfDaysToAdd);
    return toDate(new Date(result));
  }

  function stripHTML (str) {
    return str.replace(/(<([^>]+)>)/ig, "");
  }

  function toSlug (value) {
    return value.toLowerCase().replace(" ", "-");
  }

  function getAgeByDOB (DOB) {
    var ageMS = Date.parse(Date()) - Date.parse(DOB); // Calculate age in milliseconds
    var age = new Date();
    age.setTime(ageMS); // Convert to a date object
    var ageYear = (age.getFullYear() - 1970).toString().padStart(2, "0"); // Add leading zero if needed
    var ageMonth = age.getMonth().toString().padStart(2, "0"); // Add leading zero if needed
    // Return age in the format P18Y00M
    return "P" + ageYear + "Y" + ageMonth + "M";
  }

  function validateStudentAge (DOB, minAge = "", maxAge = "") {
    if (minAge) {
      if (minAge === "P06Y00M") {
        // debugger;
      }
      // Calculate the student's age in milliseconds
      var DOBDate = new Date(DOB); // Create a Date object from the string
      var ageMS = Date.now() - DOBDate.getTime(); // Use getTime() to get the timestamp
      // var ageMS = Date.now() - Date.parse(DOB);
      var age = new Date(ageMS);
      // Extract the years and months from the age
      var ageYear = (age.getUTCFullYear() - 1970).toString().padStart(2, "0"); // Leading zero
      var ageMonth = age.getUTCMonth().toString().padStart(2, "0"); // Leading zero
      // Parse minAge
      var minAgeYear = minAge.split("P").pop().split("Y")[0];
      var minAgeMonth = minAge.split("Y").pop().split("M")[0].replace(/^0+/, "");
      // Convert age and minAge to comparable floating-point numbers
      var ageYM = parseFloat(ageYear + "." + ageMonth);
      var minAgeYM = parseFloat(minAgeYear + "." + minAgeMonth);
      // If maxAge is present, parse it
      if (maxAge) {
        var maxAgeYear = maxAge.split("P").pop().split("Y")[0];
        var maxAgeMonth = maxAge.split("Y").pop().split("M")[0].replace(/^0+/, "");
        var maxAgeYM = parseFloat(maxAgeYear + "." + maxAgeMonth);
        // Check if the age is within the range (minAge <= age <= maxAge)
        if (ageYM >= minAgeYM && ageYM <= maxAgeYM) {
          return { valid: true, age: ageYear + "Y " + ageMonth + "M" };
        } else {
          return { valid: false, age: ageYear + "Y " + ageMonth + "M" };
        }
      } else {
        // If only minAge is provided, check if the age is greater than or equal to minAge
        if (ageYM >= minAgeYM) {
          return { valid: true, age: ageYear + "Y " + ageMonth + "M" };
        } else {
          return { valid: false, age: ageYear + "Y " + ageMonth + "M" };
        }
      }
    }
    return true; // If no minAge, return true by default
  }

  // function validateStudentAge (DOB, minAge = "", maxAge = "") {
  //   if (minAge) {
  //     var ageMS = Date.parse(Date()) - Date.parse(DOB);
  //     var age = new Date();
  //     age.setTime(ageMS);
  //     var ageYear = age.getFullYear() - 1970;
  //     var ageMonth = age.getMonth();
  //     var startYear = minAge.split("P").pop().split("Y")[0];
  //     var startMonth = minAge.split("Y").pop().split("M")[0].replace(/^0+/, "");
  //     var endYear = maxAge.split("P").pop().split("Y")[0];
  //     var endMonth = maxAge.split("Y").pop().split("M")[0].replace(/^0+/, "");
  //     var ageYM = parseFloat(ageYear + "." + ageMonth);
  //     var BirthStartYM = parseFloat(startYear + "." + startMonth);
  //     var BirthEndYM = parseFloat(endYear + "." + endMonth);
  //     if (ageYM >= BirthStartYM && ageYM <= BirthEndYM) {
  //       return { valid: true, age: ageYear + "Y " + ageMonth + "M" };
  //     } else {
  //       return { valid: false, age: ageYear + "Y " + ageMonth + "M" };
  //     }
  //   }
  //   return true;
  // }

  function toAge (minAge, maxAge) {
    var startYear = minAge.split("P").pop().split("Y")[0];
    var startMonth = minAge.split("Y").pop().split("M")[0];

    if (!maxAge || maxAge.trim() === "") {
      return "Student age should be equal or greater than " + startYear + "Y " + startMonth + "M";
    }

    var endYear = maxAge.split("P").pop().split("Y")[0];
    var endMonth = maxAge.split("Y").pop().split("M")[0];

    return "Student age should be between " + startYear + "Y " + startMonth + "M TO " + endYear + "Y " + endMonth + "M";
  }

  function toDisplayAge (minAge, maxAge) {
    var returnYear = "";
    var startYear = minAge.split("P").pop().split("Y")[0].replace(/^0+/, "");
    var startMonth = minAge.split("Y").pop().split("M")[0].replace(/^0+/, "");
    var endYear = maxAge.split("P").pop().split("Y")[0];
    var endMonth = maxAge.split("Y").pop().split("M")[0];
    returnYear = startYear;
    returnYear = startMonth > 0 ? returnYear + "." + startMonth + "Y " : returnYear + "Y";
    returnYear = endYear > 0 ? returnYear + " - " + endYear + "Y" : returnYear;
    returnYear = endMonth > 0 ? returnYear + " - " + endMonth + " Y " : returnYear;
    // return startYear + "." + startMonth + "Y " + " - " + endYear + "." + endMonth + "Y";
    return returnYear;
  }

  function getCreditCardType (ccnum) {
    if (!ccnum) {
      return "";
    }
    var first1 = ccnum.substring(0, 1);
    // Determine card type based on first digit
    switch (first1) {
    case "2":
      return "Mastercard";
    case "3":
      return "Amex";
    case "4":
      return "Visa";
    case "5":
      return "";
    case "6":
      return "";
    case "8":
      return "Discover";
    }
  }

  function mod10 (cardNumber) {
    var ar = new Array(cardNumber.length);
    var i = 0,
      sum = 0;
    for (i = 0; i < cardNumber.length; ++i) {
      ar[i] = parseInt(cardNumber.charAt(i));
    }
    for (i = ar.length - 2; i >= 0; i -= 2) {
      ar[i] *= 2;
      if (ar[i] > 9) ar[i] -= 9;
    }
    for (i = 0; i < ar.length; ++i) {
      sum += ar[i];
    }
    if ((sum % 10) === 0) {
      return true;
    } else {
      return false;
    }
  }

  function expired (month, year) {
    var now = new Date();
    var expiresIn = new Date(year, month, 0, 0, 0);
    expiresIn.setMonth(expiresIn.getMonth() + 1);
    if (now.getTime() < expiresIn.getTime()) return false;
    return true;
  }

  function validateCard (cardNumber, cardMonth, cardYear, cardName, cardZip) {
    if (cardNumber.length === 0) {
      notifyError({ message: "Please enter a valid card number." });
      return false;
    }
    console.log(cardMonth);
    console.log(cardYear);
    if (cardMonth === 0) {
      notifyError({ message: "Please select valid card month." });
      return false;
    }
    if (cardYear === 0) {
      notifyError({ message: "Please select valid card year." });
      return false;
    }
    if (cardName) {
      var split = cardName.split(" ");
      // we should have at least 2 individual names (first and last)
      if (split.length < 2) {
        notifyError({ message: "Please enter a valid name as it appears on card" });
        return false;
      }
    } else {
      notifyError({ message: "Please enter a name as it appears on card" });
      return false;
    }
    if (cardZip === "") {
      notifyError({ message: "Please enter a valid card zip." });
      return false;
    }
    for (var i = 0; i < cardNumber.length; ++i) {
      var c = cardNumber.charAt(i);
      if (c < "0" || c > "9") {
        notifyError({ message: "Please enter a valid card number. Use only digits. Do not use spaces or hyphens." });
        return false;
      }
    }
    var length = cardNumber.length;
    var cardType = getCreditCardType(cardNumber);
    switch (cardType) {
    case "Amex":
      if (length !== 15) {
        notifyError({ message: "Please enter a valid American Express Card number." });
        return false;
      }
      var prefix = parseInt(cardNumber.substring(0, 2));
      if (prefix !== 34 && prefix !== 37) {
        notifyError({ message: "Please enter a valid American Express Card number." });
        return false;
      }
      break;
    case "Discover":
      if (length !== 16) {
        notifyError({ message: "Please enter a valid Discover Card number." });
        return false;
      }
      prefix = parseInt(cardNumber.substring(0, 4));
      if (prefix !== 6011) {
        notifyError({ message: "Please enter a valid Discover Card number." });
        return false;
      }
      break;
    case "Mastercard":
      if (length !== 16) {
        notifyError({ message: "Please enter a valid MasterCard number." });
        return false;
      }
      prefix = parseInt(cardNumber.substring(0, 2));
      if ((prefix < 51 || prefix > 55) && (prefix < 22 || prefix > 27)) {
        notifyError({ message: "Please enter a valid MasterCard Card number." });
        return false;
      }
      break;
    case "Visa":
      if (length !== 16 && length !== 13) {
        notifyError({ message: "Please enter a valid Visa Card number." });
        return false;
      }
      prefix = parseInt(cardNumber.substring(0, 1));
      if (prefix !== 4) {
        notifyError({ message: "Please enter a valid Visa Card number." });
        return false;
      }
      break;
    }
    if (parseInt(cardNumber.substring(0, 1)) === 0) {
      notifyError({ message: "Sorry! This is not a valid credit card number." });
      return false;
    }
    if (!mod10(cardNumber)) {
      notifyError({ message: "Sorry! This is not a valid credit card number." });
      return false;
    }
    if (expired(cardMonth, cardYear)) {
      notifyError({ message: "Sorry! The expiration date is in the past and can't be saved." });
      return false;
    }
    return true;
  }

  function validateBankRoutingNumber (routingNumber) {
    var input = routingNumber;
    const values = [];
    if (!isNaN(input)) {
      values.push(input.charAt(0) * 3);
      values.push(input.charAt(1) * 7);
      values.push(input.charAt(2) * 1);
      values.push(input.charAt(3) * 3);
      values.push(input.charAt(4) * 7);
      values.push(input.charAt(5) * 1);
      values.push(input.charAt(6) * 3);
      values.push(input.charAt(7) * 7);
      values.push(input.charAt(8) * 1);
      var sum = 0;
      for (var i = 0; i < values.length; i++) {
        sum += values[i];
      }
      var modTen = parseInt(sum % 10);
      if (modTen === 0) {
        return true;
      } else {
        notifyError({ message: "Bank Routing Number invalid." });
        return false;
      }
    }
  }

  function validateBankECheck (bankName, acctName, acctNumber, routingNumber) {
    if (bankName === "") {
      notifyError({ message: "Please enter a bank name." });
      return false;
    } else if (acctName === "") {
      notifyError({ message: "Please enter a account name." });
      return false;
    } else if (acctNumber === "") {
      notifyError({ message: "Please enter a account number." });
      return false;
    } else if (routingNumber === "" || routingNumber === 0) {
      notifyError({ message: "Please enter a routing number." });
      return false;
    } else {
      return true;
    }
  }

  return {
    toCurrency,
    toNumeric,
    toPercentage,
    toPhone,
    toFax,
    toName,
    toDate,
    toDateTime,
    truncate,
    toLowercase,
    toUpperCase,
    calculateDayDiff,
    addDaysinDate,
    onlyNumber,
    onlyLetter,
    stripHTML,
    toSlug,
    toTime,
    randomIntFromInterval,
    getAgeByDOB,
    toAge,
    toDisplayAge,
    getCreditCardType,
    validateCard,
    validateBankRoutingNumber,
    validateBankECheck,
    validateStudentAge
  };
}
