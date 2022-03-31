using System;
using System.Collections.Generic;
using System.Text;

namespace MechAp
{
    public static class VehicleService 
    {
        public static string GetMakeCode(string make)
        {
            string makeCode = string.Empty;

            switch(make)
            {
                case "Chevy":
                    makeCode = "001";
                    break;
                case "Chrysler":
                    makeCode = "002";
                    break;
                case "Dodge":
                    makeCode = "003";
                    break;
                case "Ford":
                    makeCode = "004";
                    break;
                case "GMC":
                    makeCode = "005";
                    break;
                case "Honda":
                    makeCode = "006";
                    break;
                case "Mazda":
                    makeCode = "007";
                    break;
                case "Subaru":
                    makeCode = "008";
                    break;
                case "Toyota":
                    makeCode = "009";
                    break;
            }

            return makeCode;
        }

        public static string GetModelCode(string makeCode, string model)
        {
            string modelCode = string.Empty;

            switch(makeCode)
            {
                //Chevy
                case "001":
                    switch(model)
                    {
                        case "Camero":
                            modelCode = "001";
                            break;
                        case "Sonic":
                            modelCode = "002";
                            break;
                    }
                    break;
                //Chrysler
                case "002":
                    switch (model)
                    {
                        case "Pacifica":
                            modelCode = "001";
                            break;
                        case "Town & Country":
                            modelCode = "002";
                            break;
                        case "300":
                            modelCode = "003";
                            break;
                    }
                    break;
                //Dodge
                case "003":
                    switch (model)
                    {
                        case "Ram":
                            modelCode = "001";
                            break;
                        case "Challenger":
                            modelCode = "002";
                            break;
                        case "Durango":
                            modelCode = "003";
                            break;
                    }
                    break;
                //Ford
                case "004":
                    switch (model)
                    {
                        case "F-150":
                            modelCode = "001";
                            break;
                        case "Escape":
                            modelCode = "002";
                            break;
                        case "Mustang":
                            modelCode = "003";
                            break;
                    }
                    break;
                //GMC
                case "005":
                    switch (model)
                    {
                        case "Acadia":
                            modelCode = "001";
                            break;
                        case "Canyon":
                            modelCode = "002";
                            break;
                        case "Sierra":
                            modelCode = "003";
                            break;
                    }
                    break;
                //Honda
                case "006":
                    switch (model)
                    {
                        case "Accord":
                            modelCode = "001";
                            break;
                        case "Civic":
                            modelCode = "002";
                            break;
                        case "Odyssey":
                            modelCode = "003";
                            break;
                    }
                    break;
                //Mazda
                case "007":
                    switch (model)
                    {
                        case "Mazda3":
                            modelCode = "001";
                            break;
                        case "MX-5 Miata":
                            modelCode = "002";
                            break;
                        case "Mazda6":
                            modelCode = "003";
                            break;
                    }
                    break;
                //Subaru
                case "008":
                    switch (model)
                    {
                        case "Ascent":
                            modelCode = "001";
                            break;
                        case "Impreza":
                            modelCode = "002";
                            break;
                        case "Legacy":
                            modelCode = "003";
                            break;
                    }
                    break;
                //Toyota
                case "009":
                    switch (model)
                    {
                        case "Avalon":
                            modelCode = "001";
                            break;
                        case "Carolla":
                            modelCode = "002";
                            break;
                        case "Sienna":
                            modelCode = "003";
                            break;
                    }
                    break;
            }
            return modelCode;
        }

        public static string GetVehicleCode(string make, string model, int year)
        {
            string makeCode = GetMakeCode(make);
            string modelCode = GetModelCode(makeCode, model);
            string yearGroup = string.Empty;
            string vehicleCode = makeCode + modelCode;

            switch(vehicleCode)
            {
                //Chevy Camero
                case "001001":
                    if (year >= 1967 && year <= 1969)
                        yearGroup = "G1";
                    else if (year >= 1970 && year <= 1981)
                        yearGroup = "G2";
                    else if (year >= 1982 && year <= 1992)
                        yearGroup = "G3";
                    else if (year >= 1993 && year <= 2009)
                        yearGroup = "G4";
                    else if (year >= 2010 && year <= 2015)
                        yearGroup = "G5";
                    else if (year >= 2016 && year <= 2022)
                        yearGroup = "G6";
                    else
                        yearGroup = "00";
                    break;
                //Chevy Sonic
                case "001002":
                    if (year >= 2012 && year <= 2016)
                        yearGroup = "G1";
                    else if (year >= 2017 && year <= 2022)
                        yearGroup = "G2";
                    else
                        yearGroup = "00";
                    break;
                //Chrysler Pacifica
                case "002001":
                    if (year >= 2003 && year <= 2006)
                        yearGroup = "G1";
                    else if (year >= 2016 && year <= 2020)
                        yearGroup = "G2";
                    else if (year >= 2021 && year <= 2022)
                        yearGroup = "G3";
                    else
                        yearGroup = "00";
                    break;
                //Chrysler Town & Country
                case "002002":
                    if (year >= 1990)
                        yearGroup = "G1";
                    else if (year >= 1991 && year <= 1995)
                        yearGroup = "G2";
                    else if (year >= 1996 && year <= 2000)
                        yearGroup = "G3";
                    else if (year >= 2001 && year <= 2007)
                        yearGroup = "G4";
                    else if (year >= 2008 && year <= 2014)
                        yearGroup = "G5";
                    else
                        yearGroup = "00";
                    break;
                //Chrysler 300
                case "002003":
                    if (year >= 2005 && year <= 2010)
                        yearGroup = "G1";
                    else if (year >= 2011 && year <= 2022)
                        yearGroup = "G2";
                    else
                        yearGroup = "00";
                    break;
                //Dodge Ram
                case "003001":
                    if (year >= 1981 && year <= 1993)
                        yearGroup = "G1";
                    else if (year >= 1994 && year <= 2001)
                        yearGroup = "G2";
                    else if (year >= 2002 && year <= 2008)
                        yearGroup = "G3";
                    else if (year >= 2009 && year <= 2018)
                        yearGroup = "G4";
                    else if (year >= 2019 && year <= 2022)
                        yearGroup = "G5";
                    else
                        yearGroup = "00";
                    break;
                //Dodge Challenger
                case "003002":
                    if (year >= 1970 && year <= 1974)
                        yearGroup = "G1";
                    else if (year >= 1978 && year <= 1983)
                        yearGroup = "G2";
                    else if (year >= 2008 && year <= 2022)
                        yearGroup = "G3";
                    else
                        yearGroup = "00";
                    break;
                //Dodge Durango
                case "003003":
                    if (year >= 1998 && year <= 2003)
                        yearGroup = "G1";
                    else if (year >= 2004 && year <= 2009)
                        yearGroup = "G2";
                    else if (year >= 2010 && year <= 2022)
                        yearGroup = "G3";
                    else
                        yearGroup = "00";
                    break;
                //Ford F-150
                case "004001":
                    if (year >= 1975 && year <= 1979)
                        yearGroup = "G6";
                    else if (year >= 1980 && year <= 1986)
                        yearGroup = "G7";
                    else if (year >= 1987 && year <= 1991)
                        yearGroup = "G8";
                    else if (year >= 1992 && year <= 1996)
                        yearGroup = "G9";
                    else if (year >= 1997 && year <= 2003)
                        yearGroup = "G10";
                    else if (year >= 2004 && year <= 2008)
                        yearGroup = "G11";
                    else if (year >= 2009 && year <= 2014)
                        yearGroup = "G12";
                    else if (year >= 2015 && year <= 2020)
                        yearGroup = "G13";
                    else if (year >= 2021 && year <= 2022)
                        yearGroup = "G14";
                    else
                        yearGroup = "00";
                    break;
                //Ford Escape
                case "004002":
                    if (year >= 2001 && year <= 2007)
                        yearGroup = "G1";
                    else if (year >= 2008 && year <= 2012)
                        yearGroup = "G2";
                    else if (year >= 2013 && year <= 2019)
                        yearGroup = "G3";
                    else if (year >= 2020 && year <= 2022)
                        yearGroup = "G4";
                    else
                        yearGroup = "00";
                    break;
                //Ford Mustang
                case "004003":
                    if (year >= 1965 && year <= 1973)
                        yearGroup = "G1";
                    else if (year >= 1974 && year <= 1978)
                        yearGroup = "G2";
                    else if (year >= 1979 && year <= 1993)
                        yearGroup = "G3";
                    else if (year >= 1994 && year <= 2004)
                        yearGroup = "G4";
                    else if (year >= 2005 && year <= 2014)
                        yearGroup = "G5";
                    else if (year >= 2015 && year <= 2022)
                        yearGroup = "G6";
                    else
                        yearGroup = "00";
                    break;
                //GMC Acadia
                case "005001":
                    if (year >= 2007 && year <= 2016)
                        yearGroup = "G1";
                    else if (year >= 2017 && year <= 2022)
                        yearGroup = "G2";
                    else
                        yearGroup = "00";
                    break;
                //GMC Canyon
                case "005002":
                    if (year >= 2004 && year <= 2012)
                        yearGroup = "G1";
                    else if (year >= 2013 && year <= 2022)
                        yearGroup = "G2";
                    else
                        yearGroup = "00";
                    break;
                //GMC Sierra
                case "005003":
                    if (year >= 2007 && year <= 2013)
                        yearGroup = "G1";
                    else if (year >= 2014 && year <= 2018)
                        yearGroup = "G2";
                    else if (year >= 2019 && year <= 2022)
                        yearGroup = "G3";
                    else
                        yearGroup = "00";
                    break;
                //Honda Accord
                case "006001":
                    if (year >= 1976 && year <= 1981)
                        yearGroup = "G1";
                    else if (year >= 1982 && year <= 1985)
                        yearGroup = "G2";
                    else if (year >= 1986 && year <= 1989)
                        yearGroup = "G3";
                    else if (year >= 1990 && year <= 1993)
                        yearGroup = "G4";
                    else if (year >= 1994 && year <= 1997)
                        yearGroup = "G5";
                    else if (year >= 1998 && year <= 2002)
                        yearGroup = "G6";
                    else if (year >= 2003 && year <= 2008)
                        yearGroup = "G7";
                    else if (year >= 2009 && year <= 2012)
                        yearGroup = "G8";
                    else if (year >= 2013 && year <= 2017)
                        yearGroup = "G9";
                    else if (year >= 2018 && year <= 2022)
                        yearGroup = "G10";
                    else
                        yearGroup = "00";
                    break;
                //Honda Civic
                case "006002":
                    if (year >= 1973 && year <= 1979)
                        yearGroup = "G1";
                    else if (year >= 1980 && year <= 1983)
                        yearGroup = "G2";
                    else if (year >= 1984 && year <= 1987)
                        yearGroup = "G3";
                    else if (year >= 1988 && year <= 1991)
                        yearGroup = "G4";
                    else if (year >= 1992 && year <= 1995)
                        yearGroup = "G5";
                    else if (year >= 1996 && year <= 2000)
                        yearGroup = "G6";
                    else if (year >= 2001 && year <= 2005)
                        yearGroup = "G7";
                    else if (year >= 2006 && year <= 2011)
                        yearGroup = "G8";
                    else if (year >= 2012 && year <= 2017)
                        yearGroup = "G9";
                    else if (year >= 2018 && year <= 2022)
                        yearGroup = "G10";
                    else
                        yearGroup = "00";
                    break;
                //Honda Odyssey
                case "006003":
                    if (year >= 1995 && year <= 1998)
                        yearGroup = "G1";
                    else if (year >= 1999 && year <= 2004)
                        yearGroup = "G2";
                    else if (year >= 2005 && year <= 2010)
                        yearGroup = "G3";
                    else if (year >= 2011 && year <= 2017)
                        yearGroup = "G4";
                    else if (year >= 2018 && year <= 2022)
                        yearGroup = "G5";
                    else
                        yearGroup = "00";
                    break;
                //Mazda3
                case "007001":
                    if (year >= 2004 && year <= 2009)
                        yearGroup = "G1";
                    else if (year >= 2010 && year <= 2013)
                        yearGroup = "G2";
                    else if (year >= 2014 && year <= 2018)
                        yearGroup = "G3";
                    else if (year >= 2019 && year <= 2022)
                        yearGroup = "G4"; 
                    else
                        yearGroup = "00";
                    break;
                //Mazda MX-5 Miata
                case "007002":
                    if (year >= 1989 && year <= 1997)
                        yearGroup = "G1";
                    else if (year >= 1998 && year <= 2005)
                        yearGroup = "G2";
                    else if (year >= 2006 && year <= 2015)
                        yearGroup = "G3";
                    else if (year >= 2016 && year <= 2022)
                        yearGroup = "G4";
                    else
                        yearGroup = "00";
                    break;
                //Mazda6
                case "007003":
                    if (year >= 2003 && year <= 2008)
                        yearGroup = "G1";
                    else if (year >= 2009 && year <= 2013)
                        yearGroup = "G2";
                    else if (year >= 2014 && year <= 2022)
                        yearGroup = "G3";
                    else
                        yearGroup = "00";
                    break;
                //Subaru Ascent
                case "008001":
                    if (year >= 2019 && year <= 2022)
                        yearGroup = "G1";
                    else
                        yearGroup = "00";
                    break;
                //Subaru Impreza
                case "008002":
                    if (year >= 1992 && year <= 2000)
                        yearGroup = "G1";
                    else if (year >= 2001 && year <= 2007)
                        yearGroup = "G2";
                    else if (year >= 2008 && year <= 2014)
                        yearGroup = "G3";
                    else if (year >= 2015 && year <= 2016)
                        yearGroup = "G4";
                    else if (year >= 2017 && year <= 2022)
                        yearGroup = "G5";
                    else
                        yearGroup = "00";
                    break;
                //Subaru Legacy
                case "008003":
                    if (year >= 1990 && year <= 1993)
                        yearGroup = "G1";
                    else if (year >= 1994 && year <= 1999)
                        yearGroup = "G2";
                    else if (year >= 2000 && year <= 2004)
                        yearGroup = "G3";
                    else if (year >= 2005 && year <= 2009)
                        yearGroup = "G4";
                    else if (year >= 2010 && year <= 2014)
                        yearGroup = "G5";
                    else if (year >= 2015 && year <= 2019)
                        yearGroup = "G6";
                    else if (year >= 2020 && year <= 2022)
                        yearGroup = "G7";
                    else
                        yearGroup = "00";
                    break;
                //Toyota Avalon
                case "009001":
                    if (year >= 1995 && year <= 1999)
                        yearGroup = "G1";
                    else if (year >= 2000 && year <= 2004)
                        yearGroup = "G2";
                    else if (year >= 2005 && year <= 2012)
                        yearGroup = "G3";
                    else if (year >= 2013 && year <= 2018)
                        yearGroup = "G4";
                    else if (year >= 2019 && year <= 2022)
                        yearGroup = "G5";
                    else
                        yearGroup = "00";
                    break;
                //Toyota Carolla
                case "009002":
                    if (year >= 1966 && year <= 1970)
                        yearGroup = "G1";
                    else if (year >= 1971 && year <= 1974)
                        yearGroup = "G2";
                    else if (year >= 1975 && year <= 1979)
                        yearGroup = "G3";
                    else if (year >= 1980 && year <= 1983)
                        yearGroup = "G4";
                    else if (year >= 1984 && year <= 1987)
                        yearGroup = "G5";
                    else if (year >= 1988 && year <= 1991)
                        yearGroup = "G6";
                    else if (year >= 1992 && year <= 1995)
                        yearGroup = "G7";
                    else if (year >= 1996 && year <= 2000)
                        yearGroup = "G8";
                    else if (year >= 2001 && year <= 2007)
                        yearGroup = "G9";
                    else if (year >= 2008 && year <= 2013)
                        yearGroup = "G10";
                    else if (year >= 2014 && year <= 2022)
                        yearGroup = "G11";
                    else
                        yearGroup = "00";
                    break;
                //Toyota Sienna
                case "009003":
                    if (year >= 1976 && year <= 1981)
                        yearGroup = "G1";
                    else if (year >= 1982 && year <= 1985)
                        yearGroup = "G2";
                    else if (year >= 1986 && year <= 1989)
                        yearGroup = "G3";
                    else if (year >= 1990 && year <= 1993)
                        yearGroup = "G4";
                    else
                        yearGroup = "00";
                    break;
            }
            vehicleCode = vehicleCode + yearGroup;
            return vehicleCode;
        }

        public static string GetMtnFileName(string vehicleCode, string selectedMenuItem)
        {
            string fileName = vehicleCode;
            string addOn = string.Empty;

            switch(selectedMenuItem)
            {
                case "Check Tire Pressure":
                    fileName = fileName + "_tirePressure.ppt";
                    break;
                case "Tire Change":
                    fileName = fileName + "_tireChange.ppt";
                    break;
                case "Change Wiper Blades":
                    fileName = fileName + "_wiperBlade.ppt";
                    break;
                case "Change Headlight Bulb":
                    fileName = fileName + "_headlightBulb.ppt";
                    break;
                case "Change Taillight Bulb":
                    fileName = fileName + "_taillightBulb.ppt";
                    break;
                case "Change Cabin Air Filter":
                    fileName = fileName + "_cabinAirFilter.ppt";
                    break;
                case "Change Intake Air Filter":
                    fileName = fileName + "_intakeAirFilter.ppt";
                    break;
                case "Change Front Brake Pads":
                    fileName = fileName + "_frontBrakes.ppt";
                    break;
                case "Change Rear Brake Pads/Drums":
                    fileName = fileName + "_rearBrakes.ppt";
                    break;
                case "Engine Oil Change":
                    fileName = fileName + "_oilChange.ppt";
                    break;

            }
            return fileName;
        }
        public static MtnProcedure GetprocedureSelected(string vehiclecode, string selectedMenuItem)
        {
            string fileName = VehicleService.GetMtnFileName(vehiclecode, selectedMenuItem);

            MtnProcedure info = new MtnProcedure
            {
                Number = 0,
                FileName = fileName,
                ProcedureTitle = selectedMenuItem
            };
            return info;
        }
    }
}
