grammar p4;
s 						: 		importStmt* funcDcl* stmt*;
importStmt				:		Include Id Semicolon;
stmt 					: 		assignment Semicolon
						|		declaration Semicolon
						|		postfix Semicolon
						|		prefix Semicolon
						|		functioncall Semicolon
						| 		controlStructure
						|		loopStructure
						|		returnExpr;

block					:		Begin stmt* End;

returnExpr				: 		Return expr Semicolon;

funcDcl					:		Function Id Lparen params Rparen returnsStmt block;
params					: 		(param (Comma param)*)?;
param					: 		valuetype Id;
returnsStmt				: 		Returns returntype;

assignment				:		Id assnOp expr;

declaration				:		valuetype Id Modifier? (Assign expr)?;

functioncall			:		Id Lparen arguments? Rparen;
arguments				:		expr (Comma expr)*;

controlStructure		: 		ifStmt
						| 		switchStmt;
ifStmt 					: 		If Lparen expr Rparen Then block elseStmt?;
elseStmt 				: 		Else block
						| 		Else ifStmt;
						
loopStructure			: 		forexpr
						| 		foreachexpr
						| 		whileexpr;

forexpr 				: 		For Lparen Id Colon expr Dotdotdot expr Rparen block
						| 		For Lparen Id Colon expr Dotdotdot expr Comma Step expr Rparen block;
whileexpr 				: 		While Lparen expr Rparen block;
foreachexpr				: 		Foreach Lparen Id In Id Rparen block;
switchStmt 				: 		Switch Lparen Id Rparen switchBody;
switchBody 				: 		Begin switchItem* End;
switchItem 				: 		CaseKeyword expr Colon block? Break?;

expr                    :       (Negation)? condExpr;
condExpr                :       logORexpr | logORexpr '?' expr ':' condExpr;
logORexpr               :       logORexpr LogOrOp logANDexpr| logANDexpr;
logANDexpr              :       logANDexpr LogAndOp andExpr | andExpr;
andExpr                 :       andExpr EqualityOp relExpr | relExpr;
relExpr                 :       relExpr RelOp addExpr | addExpr;
addExpr                 :       addExpr AddOp multExpr | multExpr;
multExpr                :       multExpr MultOp postExpr | postExpr;
exprList                :       expr (Comma exprList)?;
postExpr                :       primExpr | Lbrace exprList Rbrace | Id Lbracket expr Rbracket;
primExpr                :       literal | Lparen expr Rparen| Id | postfix | prefix | functioncall;
literal					:	 	value;
postfix					:		Id IncrementOp;
prefix					:		IncrementOp Id;
valuetype				: 		NUMBER | BOOL | CHAR | STRING;
returntype				: 		VOID | valuetype;
value					: 		Number | bool | Char | String;
bool					: 		True | False;
assnOp					:		Assign | CompoundOp;

Modifier				: 		Lbracket (Nonzero)? Rbracket;
Number					: 		Integer | Decimal;

Function				:	 	'function';
Returns					: 		'returns';
Return					: 		'return';
Lparen					: 		'(';
Rparen					:		')';
Semicolon				: 		';';
Assign					:		'=';
Comma					:		',';
Include					: 		'include';
Begin 					: 		'begin';
End 					: 		'end';
If 						: 		'if';
Else 					: 		'else';
Then 					: 		'then';
For 					: 		'for';
While 					: 		'while';
Colon 					: 		':';
Dotdotdot 				: 		'...';
Step 					: 		'step';
Foreach 				: 		'foreach';
In 						: 		'in';
Switch 					: 		'switch';
CaseKeyword 			: 		'case';
Break 					: 		'break';
Dot						: 		'.';

LogOrOp					:		'||';
LogAndOp				:		'&&';
EqualityOp				:		'==' | '!=';
RelOp 					: 		'<' | '>' |  '<=' | '>=';
AddOp					:		'+' | '-';
MultOp					:		'*' | '/' | '%';
Lbracket 				:		'[';
Rbracket 				:		']';
Lbrace					:		'{';
Rbrace					:		'}';
CompoundOp				:	  	'*=' | '/=' |  '%=' | '+=' | '-=' | '^=';
IncrementOp				:		'++' | '--';
Negation				:		'!';



//Types
NUMBER					: 		'number';
STRING					:		'string';
CHAR					:		'char';
BOOL					: 		'bool';
VOID					: 		'void';

True					:		'true';
False					:		'false';

Id						:		Idregex (Dot Idregex)*;

fragment Idregex		: 		[a-zA-Z][a-zA-Z0-9_]*;
fragment Digit			: 		'0'..'9';
fragment Nonzero		: 		'1'..'9'Digit*;
Decimal					: 		Digit+[.]Digit+;
Integer					: 		'0' | Nonzero;
String					: 		'"'~["]*'"';
Char					: 		'\''~[']'\'';

LineComment				: 		'/''/' ~[\r\n]* -> skip;
MultiComment			: 		'/''*' .*? '*''/' -> skip;

//Skips
WS  					: 		[ \t\r\n]+ -> skip;