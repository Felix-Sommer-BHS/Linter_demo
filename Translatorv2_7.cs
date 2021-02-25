using System;

namespace Testing
{
    public class Translatorv2_7 : ITranslator
    {
        public ConveyData TranslateInformation(string dat_wpa)
        {
            int count = 0;
            int length;
            string tempSave;

            ConveyData c = new ConveyData();

            length = 4;
            tempSave = dat_wpa.Substring(count, length);
            count += length;
            c.DataSetCounter = Convert.ToInt32(tempSave);
            ////Console.WriteLine("1. Angabe DataSetCounter 4 Zahlen");
            ////Console.WriteLine(c.dataSetCounter); // eventuell noch führende nullen ergänzen

            length = 1;
            c.CostumerID = dat_wpa.Substring(count, length);  // eventuell noch Kontrolle ob auch wirklich A, B ider C
            count += length;

            //Console.WriteLine("2. Angabe Costumer ID 1 Buchstabe A,B oder C");
            //Console.WriteLine(c.costumerID);
            length = 1;
            tempSave = dat_wpa.Substring(count, length);
            c.StackerNr = Convert.ToInt32(tempSave);   // noch abfrage ob zweischen 1 und 4
            count += length;

            //Console.WriteLine("3. Angabe Stacker NUmmer 1 Zahl zw. 1 und 4");
            //Console.WriteLine(c.stackerNr);
            length = 1;
            tempSave = dat_wpa.Substring(count, length);
            c.DataSetID = Convert.ToInt32(tempSave);   // noch abfrage ob zwischen 1 und 5
            count += length;

            //Console.WriteLine("4. Angabe Data Set ID 1 Zahl zw. 1 und 5");
            //Console.WriteLine(c.dataSetID);
            length = 1;
            tempSave = dat_wpa.Substring(count, length);
            c.MultiStacking = Convert.ToInt32(tempSave);   // noch abfrage ob 0 oder 1
            count += length;

            //Console.WriteLine("5. Angabe Multi stacking 1 Zahl, 0 oder 1");
            //Console.WriteLine(c.multiStacking);

            //This data is used for Multi-stacking only In all other cases, it is overwritten by -> 1
            // As for Multi - stacking, when several orders are on top of each other
            //          -> 12 means one first of 2 stacks
            length = 2;
            tempSave = dat_wpa.Substring(count, length);
            c.MultiStackPartial = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("6. Angabe Multi stacking partial");
            //Console.WriteLine(c.multiStackPartial);
            length = 2;
            tempSave = dat_wpa.Substring(count, length);
            c.MultiStackNrPartial = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("7. Angabe Number of multi stacks ??"); // whats the meaning and why we need to digits
            //Console.WriteLine(c.multiStackNrPartial);
            length = 20;
            c.OrderNumber = dat_wpa.Substring(count, length);
            count += length;

            //Console.WriteLine("8. Angabe order number, 20 digits");
            //Console.WriteLine(c.orderNumber);
            length = 3;
            tempSave = dat_wpa.Substring(count, length);
            c.PartNr = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("9. Angabe part number, 3 stellige Zahl");
            //Console.WriteLine(c.partNr);
            length = 20;
            c.CostumerName = dat_wpa.Substring(count, length);
            count += length;

            //Console.WriteLine("10. Angabe costumer name, 20 digits");
            //Console.WriteLine(c.costumerName);
            length = 10;
            c.ProcessingMachine = dat_wpa.Substring(count, length);
            count += length;

            //Console.WriteLine("11. Angabe prcessing machine, 10 digits");
            //Console.WriteLine(c.processingMachine);
            length = 1;
            tempSave = dat_wpa.Substring(count, length);
            c.DestLine = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("12. Angabe destination line, 1 stellige Zahl");
            //Console.WriteLine(c.destLine);
            length = 8;
            tempSave = dat_wpa.Substring(count, length);
            c.LengthIndPartStack = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("13. Angabe length of individual partial Stack, 8 stellige Zahl");
            //Console.WriteLine(c.lengthIndPartStack); // führende nullen bei int weg
            length = 6;
            tempSave = dat_wpa.Substring(count, length);
            c.OutWidthIndPartStack = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("14. Angabe out width of individual partial Stack, 6 stellige Zahl");
            //Console.WriteLine(c.outWidthIndPartStack); // führende nullen bei int weg

            // was die nummer sagt scheint etwas komplizierter
            length = 6;
            tempSave = dat_wpa.Substring(count, length);
            c.NrSheetsPartStack = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("15. Angabe nr of sheets per individual partial Stack, 6 stellige Zahl");
            //Console.WriteLine(c.nrSheetsPartStack); // führende nullen bei int weg

            //This data is available with the use of an optional side chamber stacker only.
            length = 6;
            tempSave = dat_wpa.Substring(count, length);
            c.OverallNrStacks = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("16. Angabe overall nr of stack, 6 stellige Zahl");
            //Console.WriteLine(c.overallNrStacks); // führende nullen bei int weg

            //This data is available with the use of an optional side chamber stacker only.
            length = 8;
            tempSave = dat_wpa.Substring(count, length);
            c.OverallWidthStackPackage = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("17. Angabe overall length of stack package, 8 stellige Zahl");
            //Console.WriteLine(c.overallWidthStackPackage); // führende nullen bei int weg

            //This data is available with the use of an optional side chamber stacker only.
            length = 8;
            tempSave = dat_wpa.Substring(count, length);
            c.OveralllengthStackPackage = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("18. Angabe overall length of stack package, 8 stellige Zahl");
            //Console.WriteLine(c.overalllengthStackPackage); // führende nullen bei int weg

            //This data is available with the use of an optional side chamber stacker only.
            length = 8;
            tempSave = dat_wpa.Substring(count, length);
            c.OverallheightStackPackage = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("19. Angabe overall length of stack package, 8 stellige Zahl");
            //Console.WriteLine(c.overallheightStackPackage); // führende nullen bei int weg

            //This data is available with the use of an optional side chamber stacker only.
            length = 2;
            tempSave = dat_wpa.Substring(count, length);
            c.NrStackswidthwise = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("20. Angabe number of stacks widthwise, 2 stellige Zahl");
            //Console.WriteLine(c.nrStackswidthwise); // führende nullen bei int weg
            //if sidechamber is active

            //This data is available with the use of an optional side chamber stacker only.
            length = 2;
            tempSave = dat_wpa.Substring(count, length);
            c.NrStackslengthwise = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("20. Angabe number of stacks lengthwise, 2 stellige Zahl");
            //Console.WriteLine(c.nrStackslengthwise); // führende nullen bei int weg
            //if sidechamber is active

            //This data is available with the use of an optional side chamber stacker only.
            length = 2;
            tempSave = dat_wpa.Substring(count, length);
            c.NrStacksabove = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("21. Angabe number of stacks above each other, 2 stellige Zahl");
            //Console.WriteLine(c.nrStacksabove); // führende nullen bei int weg
            //if sidechamber is active

            //This data is available with the use of an optional side chamber stacker only.
            length = 1;
            tempSave = dat_wpa.Substring(count, length); // prüfe ob 0 oder 1 !!!!!!!
            c.StackConfNominal = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("22. Angabe stack config nominal 0 oder 1, 1 stellige Zahl");
            //Console.WriteLine(c.stackConfNominal);
            length = 1;
            tempSave = dat_wpa.Substring(count, length); // prüfe ob 0 oder 1 !!!!!!!
            c.IntermLayerForPackages = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("23. Angabe intermediate layer of stack packages, 1 stellige Zahl");
            //Console.WriteLine(c.intermLayerForPackages);
            length = 1;
            tempSave = dat_wpa.Substring(count, length); // prüfe ob 0 oder 1 !!!!!!!
            c.LastStack = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("24. Angabe last stack 0 or 1, 1 stellige Zahl");
            //Console.WriteLine(c.lastStack);
            length = 1;
            tempSave = dat_wpa.Substring(count, length); // prüfe ob 0 oder 1 !!!!!!!
            c.LastRunCostumer = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("25. Angabe last run costumer 0 or 1, 1 stellige Zahl");
            //Console.WriteLine(c.lastRunCostumer);
            length = 1;
            tempSave = dat_wpa.Substring(count, length); // prüfe ob 0 oder 1 !!!!!!!
            c.DischargeDirection = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("26. Angabe discharge dircetion 0: OS or 1: DS, 1 stellige Zahl");
            //Console.WriteLine(c.dischargeDirection);

            /*
            The fields “Expected number of stack packages per partial order” and “Expected
            number of stack packages per overall order” may be not correct in case of
            - number *16) (splitted / seperated stack by additionally discharge)
                - if AOC suppression is active
            - if Multi-stacking is active
             */

            length = 4;
            tempSave = dat_wpa.Substring(count, length);
            c.ExpNrStackPackPartialOrder = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("27. Angabe expected number of Stack packages per partial Order, 4 stellige Zahl");
            //Console.WriteLine(c.expNrStackPackPartialOrder);
            length = 4;
            tempSave = dat_wpa.Substring(count, length);
            c.ExpNrStackPackOverallOrder = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("28. Angabe expected number of Stack packages per overall Order, 4 stellige Zahl");
            //Console.WriteLine(c.expNrStackPackOverallOrder);
            length = 20;
            c.SetupIdentification = dat_wpa.Substring(count, length);
            count += length;

            //Console.WriteLine("29. Angabe setuo identification, 20 stellig");
            //Console.WriteLine(c.setupIdentification);
            length = 2;
            tempSave = dat_wpa.Substring(count, length);
            c.NrOuts = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("30. Angabe number of Outs, 2 stellige Zahl");
            //Console.WriteLine(c.nrOuts);

            //scoring and knife position
            length = 6;

            //Console.WriteLine("31. Angabe scoring and knife position, 24 * 6 stellig");
            int i = 0;
            int v;
            while (i < 24)
            {
                tempSave = dat_wpa.Substring(count, length);

                v = Convert.ToInt32(tempSave);
                c.ScoringKnifePos[i] = v;

                //Console.WriteLine(c.scoringKnifePos[i]);
                i += 1;
                count += length;
            }

            length = 6;
            tempSave = dat_wpa.Substring(count, length);
            c.TotalCutsActualOrder = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("32. Angabe total cuts acutal order counted by stacker, 6 stellige Zahl");
            //Console.WriteLine(c.totalCutsActualOrder);
            length = 2;
            tempSave = dat_wpa.Substring(count, length);
            c.LastStackModified = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("33. Angabe last stack modified (no of cuts), 2 stellige Zahl");
            //Console.WriteLine(c.lastStackModified);
            length = 6;
            tempSave = dat_wpa.Substring(count, length);
            c.WidthStackGroup = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("34. Angabe widht of stack group, 6 stellige Zahl");
            //Console.WriteLine(c.widthStackGroup);
            length = 2;
            tempSave = dat_wpa.Substring(count, length);
            c.NrOutsForStackGroup = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("35. Angabe number of outs for stack groups, 2 stellige Zahl");
            //Console.WriteLine(c.nrOutsForStackGroup);
            length = 1;
            tempSave = dat_wpa.Substring(count, length);
            c.LastStackStore = Convert.ToInt32(tempSave);
            count += length;

            //Console.WriteLine("36. Angabe last stack store, 0: no store, 1: store  ");
            //Console.WriteLine(c.lastStackStore);
            length = 11;
            c.Reserved = dat_wpa.Substring(count, length);
            count += length;

            //Console.WriteLine("37. Angabe reserved, 11 zeichen  ");
            //Console.WriteLine(c.reserved);
            return c;
        }
    }
}