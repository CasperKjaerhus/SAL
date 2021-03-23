grammar p4;
s 					:	importstmts initStmts;
importstmts 		:	importstmt importstmts
					|	;
initStmts 			:	dcl initStmts
					|	;
importstmt 			:	Include Id;
dcl 				:	funcDcl
					|	varDcl;
varDcl 				:	Type Id
					| 	Type Id modifier
					|	Type Id Assignment expr
					|	Type Id modifier Assignment expr;
modifier 			:	Lbracket Size Rbracket
					|	Lbracket Rbracket;
funcDcl 			:	Function Id Lparen params Rparen Returns Type body
					|	Function Id Lparen Rparen Returns Type body;
params 				:	param
					|	param Comma params;
param 				:	Type Id;
body 				:	Begin stmts End;
stmts 				:	varDcl stmts							// Hvad med funcDcl inde i en funcDcl?
					|	controlExpr stmts
					|	functioncall stmts
					|	returnExpr stmts
					|	;
expr 				: 	relExpr (BoolOp relExpr)*;				// Hvad med negation?
relExpr 			:	addExpr (RelOp addExpr)*;
addExpr				: 	mulExpr (AddOp mulExpr)*;
mulExpr				: 	term (MulOp term)*;
term				: 	val | Lparen expr Rparen;
val					: 	Id | num | functioncall;
controlExpr			:	ifExpr
					|	forExpr
					|	whileExpr
					|	foreachExpr
					|	switchExpr;
ifExpr 				:	If Lparen expr Rparen Then body elseExpr;
elseExpr 			:	Else body
					|	Else ifExpr
					|	;
forExpr 			:	For Lparen Id Colon expr Dotdotdot expr Rparen body
					|	For Lparen Id Colon expr Dotdotdot expr Comma Step expr Rparen body;
whileExpr 			:	While Lparen expr Rparen body;
foreachExpr			:	Foreach Lparen Id In Id Rparen body;
switchExpr 			:	Switch Lparen Id Rparen switchBody;
switchBody 			:	Begin cases End;
cases 				:	r_case
					|	r_case cases;
r_case 				:	CaseKeyword val Colon 					// Hvad med blokke/scope/Begin-End?
					|	CaseKeyword val Colon Break
					|	CaseKeyword val Colon body
					|	CaseKeyword val Colon body Break;
functioncall		:	Id Lparen arguments Rparen 
					| 	Id Lparen Rparen;
arguments 			:	val | val Comma arguments;
returnExpr 			:	Return expr;
num 				:	Integers
					|	Decimal;

//Terminals
Include				:	'include';
Type 				:	'number'
					|	'string'
					|	'char'
					|	'bool'
					| 	'void';
RelOp 				:	'<'
					|	'>'
					|	'=='
					|	'!='
					|	'<='
					|	'>=';
BoolOp 				:	'&&'
					|	'||';
AddOp 				:	'+'
					|	'-';
MulOp 				:	'*'
					|	'/'
					|	'%';
Assignment 			:	'=';
Function 			:	'function';
Lbracket 			:	'[';
Rbracket 			:	']';
Lparen 				:	'(';
Rparen 				:	')';
Return 				:	'return';
Returns 			:	'returns';
Comma 				:	',';
Begin 				:	'begin';
End 				:	'end';
If 					:	'if';
Else 				:	'else';
Then 				:	'then';
For 				:	'for';
While 				:	'while';
Colon 				:	':';
Dotdotdot 			:	'...';
Step 				:	'step';
Foreach 			:	'foreach';
In 					:	'in';
Switch 				:	'switch';
CaseKeyword 		:	'case';
Break 				:	'break';

//Regex
Size				:	[1-9]+Digit*;
Id 					:	[a-zA-Z]+[a-zA-Z0-9_]*;
Integers			:	[1-9]+Digit*
					|	'0'; 
Decimal				:	Integers '.' Digit*;
fragment Digit		:	[0-9];

LineComment			:	'/''/' ~[\r\n]* -> skip;
MultiComment		:	'/''*' .*? '*''/' -> skip;
//Skips
WS  				: [ \t\r\n]+ -> skip;
