This document is a summary for my edited parts.

Check the main repo for Triggernometry documentations:
https://github.com/paissaheavyindustries/Triggernometry

# What's New
## Bug Fixes
### Fixed https://github.com/paissaheavyindustries/Triggernometry/issues/92)https://github.com/paissaheavyindustries/Triggernometry/issues/92:  
The original regex for string function could not parse `func:length:3*(1+2)` correctly, which considers `length:3*` as the function name and `1+2` as the argument.  
The regex was editted to solve this issue; it could now also match the whole expression in one step instead of parsing the `funcval` by searching the index of `:` later.  
### Fixed a bug in the method `VariableList.Insert`:
The original code inserted `null` as placeholders when the given index is longer than the length of the list (should use new `Variable` instead).  
The parser could not get these null values in expressions; it also caused the list could not be double-clicked in the variable viewer.   
### Fixed a bug in the method `VariableList.Set`:
The original code inserted 1 less empty `Variable` into the list as placeholders.    
It caused the program trying to set the value at the given `index` into the list with the length `index - 1` and failed.  
### Fixed a bug in the function `SplitArguments`:  
The original function had complex checks for single and double quotes, which might result in incorrect `args` list when encountering unmatched quote pairs or consecutive commas.    
The editted code now utilizes regular expressions to accurately extract all parameters located between the string's beginning, end, and commas.  
Additionally, trimming has been added for parameters without quotes.  
e.g. (1,2,  3  ,"  4  ",   "5"  , "'", ', ', ) is now parsed into a list with the arguments:   
`1` `2` `3` `  4  ` `5` `'` `, ` `​`.  

## Added new methods for list variables:  
The following part uses `list = [1,2,3,4,5,6]` as an example.  
### · `listname.count(str)`  
Counts the repeated times of a given string in the list.    
e.g. `lvar:list.count(2)` = `1`, `lvar:list.count(10)` = `0`  
### · `joinslice(joiner = ",", start, end, step)`
Also as `join(...)`  
All parameters could be omitted.    
The final 3 arguments works as the list slices in Python which accepts negative indices as reversed indices;    
however the positive indices counts from 1 instead of 0 to be consistent with the current features.  
e.g. `lvar:list.joinslice` = `1,2,3,4,5,6`, `lvar:list.joinslice(" ",2,5)` = `2 3 4`, `lvar:list.joinslice(,-1,1,-1)` = `6,5,4,3,2`.  
### · `sumslice(start, end, step)`, also as `sum(...)`
Similar to the previous method. Adding all the values which could be parsed as `double` in the given slice and returns the sum.  
e.g. `lvar:list.sumslice` = `21`, `lvar:list.sumslice(,4)` = `6`, `lvar:list.joinslice(,,2)` = `15`.  

## Added new methods for table variables:  
The following part uses this `table` as an example:
```
11, 12, 13, 14
21, 22, 23, 24
31, 32, 33, 34
```
### · `join(colJoiner = ",")`
Connects the values of all cells in the table into a string.  
The column joiner could be given as an argument and the row joiner is fixed as "\n".  
### · `hjoinslice(rowIndex, joiner = ",", start, end, step)`  
### · `vjoinslice(colIndex, joiner = ",", start, end, step)`  
Also as `hjoin(...)` and `vjoin(...)`  
Similar to list.joinslice(joiner = ",", start, end, step), which horizontally / vertically extracts the row / column with the given index and joins the corresponding slice to a string.  
e.g. `list.vjoin(2)` = `12,22,32`, `list.hjoin(3," ",2,,2)` = `32 34`  
### · `hlookup(targetValue, rowIndex = 1, direction = 1)`  
### · `vlookup(targetValue, colIndex = 1, direction = 1)`    
Also as `hl(...)` and `vl(...)`  
Look up the given value horizontally / vertically in the given row / col index. Returns the first found col / row index, or `0` when not found.  
The third parameter `direction` is set to 1 as default. A positive integer means searching from the beginning, and non-positive integer means searching from the end.  
e.g. `list.vlookup(21)` = `2`, `list.hlookup(00)` = `0`, `list.hlookup(32, 3, -1)` = `2` (`-1` works the same as `1` in this case since there is only one 32.)  

## Added / Updated functions for string variables:  
### · `func:parsedmg:hexstr`  
Parse the given hexstr damage value in the `0x15` / `0x16` ACT loglines to the corresponding decimal value.  
Rule: padleft the hexstr with `0` to 8 digits like `XXXXYYZZ`, then convert `ZZXXXX` to decimal.  
### · `func:slice(start, end, step):str`  
Works the same as the string slice in Python. Indices starts from 0 and negative indices means counting from the end.  
e.g. `func:slice(-3):01234` = `234`, `func:slice(1,4):01234` = `123`, `func:slice(,,-1):01234` = `43210`, `func:slice(3,,-2):01234` = `31`  
### · `func:pick(index, separator = ","):str`
### · `func:pick(index, separator charcode):str`    
Separates the given string by the given separator (default as ","). Returns the separated index of string counting from 0. Also supports negative values.  
Separator could be given as a charcode, but `0`-`9` would be considered as a number character (since nobody would use those control characters with charcode 0-9 in Triggernometry).  
e.g. `func:pick(3):north,west,south,east` = `east`, `func:pick(-1,"--"):1--22--3--44--5` = `5`, `func:pick(1,48):10220304405` = `22` (charcode of `0` is 48)  
### · Added string arguments support to `padleft`, `padright`, `trim`, `trimleft`, `trimright`  
Similar to the `pick` function above, these functions now also accepts character arguments given as the character itself instead of only by its charcode.    
Get rid of those 5-digit charcodes of CJK-region characters. (even full-width spaces)    

## Added numeric function: 
### · `roundir(θ, n)` or `roundir(dx, dy, n)`
Matches the given direction (in radian or as `dx`/`dy` offsets) to the direction in a circle divided into `|n|` segments, and returns the index of the direction.   
Could combine with `func:pick(index)` and easily output any direction as a string from a radian / coordinate with no more complicated `arctan2` and `mod` calculations.  
The sign of `n` indicates 2 division modes: north is the segment point or the border of 2 segments, as shown below.  
e.g. `roundir(-1.57,4)` = `1` (West), `roundir(8,-6,-4)` = `3` (NE)
![image](https://github.com/paissaheavyindustries/Triggernometry/assets/85232361/b7ab1f13-c5ba-4609-b588-b066d5d9d4e1)

## Added `generate` action for list actions:  
Generates a list variable using the first index of the expression as the separator, and the remained part as the given string.    
Easily generates a list directly from a given string in a single action.  
Could also generate a list from the slice of another list or even a row/column of a table in a single action, if combined with `list.join`, `table.hjoin`, `table.vjoin`.  

## Added supports for negative indices:  
Supports for negative indices are added to those original features :  
· Peeking values in lvar and tvar, e.g. `${lvar:list[-2]}` gives the second last element. The original keyword `last` is also redirected to `-1`.  
· tvarrl and tvarcl, e.g. `${tvarrl:table[title][-2]}` gives the second last element in the selected row. Also, `${tvarrl:table[title][0]}` looks up the row index of `title`.  
· Insert / Set action of list / table variable actions.  
· The `start` argument in `func:substring(start, ...)`.  
The changes have no conflict with the original version since negative indices had no definations.  

## Abbrevations for improving user experience：  
Several frequently-used words could now be replaced with their abbrevations:  
`${numeric:...}`, `${string:...}`, `${func:...}` could be short as `${n:...}`, `${s:...}`, `${f:...}`;  
`${_ffxiventity[...].prop}`, `${_ffxivparty[...].prop}` could be short as `${_entity[...].prop}`, `${_party[...].prop}`;  
`${_ffxivplayer}`, `${_ffxiventity[${_ffxivplayer}].prop}` could be short as `${_me}`, `${_me.prop}`;  
`${lvar:list.indexof(...)}`, `${lvar:list.lastindexof(...)}` could be short as `${lvar:list.i(...)}`, `${lvar:list.li(...)}`;  
`${func:indexof(...):str}`, `${func:laseindexof(...):str}` could be short as `${func:i(...):str}`, `${func:li(...):str}`;  

## To-do List
· I18n (added part)  
· Previous translations  
· rewrite list.sum() / list.join() with the new SplitArgs function  
· deal with out-of-range indices in str.slice()  
· add slice supports for table.h/vjoin()  
· ${_me}  
· table.join(colJoiner, rowJoiner, colstart, colend, colstep, rowstart, rowend, rowstep)  
· distance=>d(x1, y1, x2, y2), angle/θ(x1, y1, x2, y2)  
· projecth(x1, y1, θ1, x2, y2), projectd(x1, y1, θ1, x2, y2) (could be negative), relangle/relθ(x1, y1, θ1, x2, y2)  
· func:pick() respects negative arguments   
· func:repeat(times, joiner = ""):str  for len(str) > 1.  
· Table action: generate from string (expr = colJoiner + rowJoiner + str)  
· Table action: seperate the expr with its first character then insert after the given row / col index  
· Sort the current list actions order  
· check the definition for "" as an arg  
