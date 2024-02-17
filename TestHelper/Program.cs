// See https://aka.ms/new-console-template for more information
using TestHelper;


//test result..
Test t = new Test();
#region do insert
//do insert
//var i = t.insertEmployeeReturnAffectedRowCount();
//Console.WriteLine("insertEmployee: " + i);
var obj = t.insertEmployeeReturnScalar();
Console.WriteLine("insertEmployeeReturnScalar: 1" + (obj == null));
Console.WriteLine("insertEmployeeReturnScalar: 2" + obj);
Console.WriteLine("insertEmployeeReturnScalar: 3" + obj.GetType().ToString());

//obj = t.updateEmployeeReturnScalar(102);
//Console.WriteLine("updateEmployeeReturnScalar: " + obj);
#endregion
#region select all
//select all
var listdic = t.selectEmployeesReturnListOfDictionary();
Console.WriteLine("selectEmployeesReturnListOfDictionary: Row - " + listdic.Count + ", Column - "+ listdic[0].Count);
#endregion
#region select by id
/*
//select by id
var dic = t.selectEmployeeByIdReturnListOfDictionary(1446);

Console.WriteLine("selectEmployeesReturnListOfDictionary: " + String.Join(",",dic.ToArray()));
*/

#endregion
#region do update
/*
//do update 
var i = t.updateEmployeeReturnAffectedRowCount(1446);
Console.WriteLine("updateEmployee: "+i);


dic = t.selectEmployeeByIdReturnListOfDictionary(1446);

Console.WriteLine("selectEmployeesReturnListOfDictionary: " + String.Join(",", dic.ToArray()));
*/
#endregion

