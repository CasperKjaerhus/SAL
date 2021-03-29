grammar p4v4;
s 			: (importStmt)* (initStmt)*;
importStmt			: Include Id;
initStmt 			: varDcl | funcDcl;
varDcl				: Type Id (Modifier)?
					| Type Id Assignment expr
					| Type Id Modifier Assignment list;
list				: LBrace val? (Comma val)* RBrace;
funcDcl 			: Function Id Lparen params Rparen Returns Type body
					| Function Id Lparen Rparen Returns Type body;
params				: param? (Comma param)*;
param				: Type Id;
body				: Begin stmt* End;
stmt 				: varDcl
					| controlStructure
					| functioncall
					| returnStmt;
controlStructure	: ifStmt
					| forExpr
					| foreachExpr
					| whileExpr
					| switchStmt;
returnStmt			: Id 
					| val 
					| expr;
functioncall		: Id Lparen argument* Rparen;
argument 			: val (Comma val)*;
ifStmt 				: If Lparen predExpr Rparen Then body elseStmt?;
elseStmt 			: Else body
					| Else ifStmt;
forExpr 			: For Lparen Id Colon expr Dotdotdot expr Rparen body
					| For Lparen Id Colon expr Dotdotdot expr Comma Step expr Rparen body;
whileExpr 			: While Lparen predExpr Rparen body;
foreachExpr			: Foreach Lparen Id In Id Rparen body;
switchStmt 			: Switch Lparen Id Rparen switchBody;
switchBody 			: Begin switchItem* End;
switchItem 			: CaseKeyword val Colon body? Break?;

expr 				: mathExpr | predExpr;
predExpr 			: relExpr | boolExpr;
relExpr				: mathExpr ( RelOp mathExpr)*;
boolExpr 			: andExpr (OrOp andExpr)*;
andExpr				: boolTerm (AndOp boolTerm)*;
boolTerm 			: Id | Bool | functioncall | Lparen predExpr Rparen;
mathExpr			: mulExpr (AddOp mulExpr)*;
mulExpr				: mathTerm (MulOp mathTerm)*;
mathTerm			: val | Lparen mathExpr Rparen;

val					: UnIncreDecre? Id UnIncreDecre?
					| literal
					| functioncall 
					| Id Dot Id 
					| Id Lbracket UnIncreDecre? indexVal UnIncreDecre? Rbracket
					| Id Dot functioncall;
indexVal			: Integer
					| Id
					| Id Dot Id
					| functioncall;
literal				: Integer 
					| Decimal
					| String
					| Char
					| Bool;

Negation			: '!';
AndOp 				: '&&';
OrOp				: '||';
RelOp 				: '<'
					| '>'
					| '=='
					| '!='
					| '<='
					| '>=';

UnaryOp				: '+' | '-';
UnIncreDecre		: '++' | '--';

CompoundStmt		: '+='  								// sup?
					| '-=' 
					| '/=' 
					| '*=' 
					| '%=';

AddOp 				: '+'
					| '-';
MulOp 				: '*'
					| '/'
					| '%';
Assignment 			: '=';
Function 			: 'function';
Lbracket 			: '[';
Rbracket 			: ']';
Lparen 				: '(';
Rparen 				: ')';
LBrace				: '{';
RBrace				: '}';
Return 				: 'return';
Returns 			: 'returns';
Comma 				: ',';
Begin 				: 'begin';
End 				: 'end';
If 					: 'if';
Else 				: 'else';
Then 				: 'then';
For 				: 'for';
While 				: 'while';
Colon 				: ':';
Dotdotdot 			: '...';
Step 				: 'step';
Foreach 			: 'foreach';
In 					: 'in';
Switch 				: 'switch';
CaseKeyword 		: 'case';
Break 				: 'break';
Dot					: '.';

Type				: 'number' | 'string' | 'bool' | 'void';
String				: '"'~["]*'"';
Char				: '\''~[']'\'';
Bool				: 'true' | 'false';
Id					: ([a-zA-Z]([a-zA-Z0-9_])*);
Include				: 'include';
Modifier			: Lbracket (Nonzero)? Rbracket;
fragment Digit		: '0'..'9';
fragment Nonzero	: '1'..'9'Digit*;
Decimal				: Digit+[.]Digit+;
Integer				: '0' | Nonzero;

LineComment			: '/''/' ~[\r\n]* -> skip;
MultiComment		: '/''*' .*? '*''/' -> skip;
//Skips
WS  				: [ \t\r\n]+ -> skip;
