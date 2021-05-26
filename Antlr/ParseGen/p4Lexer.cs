//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from p4.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public partial class p4Lexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, Number=3, Function=4, Returns=5, Return=6, Lparen=7, Rparen=8, 
		Semicolon=9, Assign=10, Comma=11, Include=12, Begin=13, End=14, If=15, 
		Else=16, Then=17, For=18, While=19, Colon=20, Dotdotdot=21, Step=22, Foreach=23, 
		In=24, Switch=25, CaseKeyword=26, Break=27, Dot=28, LogOrOp=29, LogAndOp=30, 
		EqualityOp=31, RelOp=32, AddOp=33, MultOp=34, Lbracket=35, Rbracket=36, 
		Lbrace=37, Rbrace=38, CompoundOp=39, IncrementOp=40, Negation=41, NUMBER=42, 
		STRING=43, CHAR=44, BOOL=45, VOID=46, True=47, False=48, Id=49, Nonzero=50, 
		Decimal=51, Integer=52, String=53, Char=54, LineComment=55, MultiComment=56, 
		WS=57;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "Number", "Function", "Returns", "Return", "Lparen", "Rparen", 
		"Semicolon", "Assign", "Comma", "Include", "Begin", "End", "If", "Else", 
		"Then", "For", "While", "Colon", "Dotdotdot", "Step", "Foreach", "In", 
		"Switch", "CaseKeyword", "Break", "Dot", "LogOrOp", "LogAndOp", "EqualityOp", 
		"RelOp", "AddOp", "MultOp", "Lbracket", "Rbracket", "Lbrace", "Rbrace", 
		"CompoundOp", "IncrementOp", "Negation", "NUMBER", "STRING", "CHAR", "BOOL", 
		"VOID", "True", "False", "Id", "Idregex", "Digit", "Nonzero", "Decimal", 
		"Integer", "String", "Char", "LineComment", "MultiComment", "WS"
	};


	public p4Lexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public p4Lexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'main'", "'?'", null, "'function'", "'returns'", "'return'", "'('", 
		"')'", "';'", "'='", "','", "'include'", "'begin'", "'end'", "'if'", "'else'", 
		"'then'", "'for'", "'while'", "':'", "'...'", "'step'", "'foreach'", "'in'", 
		"'switch'", "'case'", "'break'", "'.'", "'||'", "'&&'", null, null, null, 
		null, "'['", "']'", "'{'", "'}'", null, null, "'!'", "'number'", "'string'", 
		"'char'", "'bool'", "'void'", "'true'", "'false'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "Number", "Function", "Returns", "Return", "Lparen", 
		"Rparen", "Semicolon", "Assign", "Comma", "Include", "Begin", "End", "If", 
		"Else", "Then", "For", "While", "Colon", "Dotdotdot", "Step", "Foreach", 
		"In", "Switch", "CaseKeyword", "Break", "Dot", "LogOrOp", "LogAndOp", 
		"EqualityOp", "RelOp", "AddOp", "MultOp", "Lbracket", "Rbracket", "Lbrace", 
		"Rbrace", "CompoundOp", "IncrementOp", "Negation", "NUMBER", "STRING", 
		"CHAR", "BOOL", "VOID", "True", "False", "Id", "Nonzero", "Decimal", "Integer", 
		"String", "Char", "LineComment", "MultiComment", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "p4.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static p4Lexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', ';', '\x1A9', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', '/', '\t', '/', 
		'\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', '\x4', '\x32', 
		'\t', '\x32', '\x4', '\x33', '\t', '\x33', '\x4', '\x34', '\t', '\x34', 
		'\x4', '\x35', '\t', '\x35', '\x4', '\x36', '\t', '\x36', '\x4', '\x37', 
		'\t', '\x37', '\x4', '\x38', '\t', '\x38', '\x4', '\x39', '\t', '\x39', 
		'\x4', ':', '\t', ':', '\x4', ';', '\t', ';', '\x4', '<', '\t', '<', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x5', '\x4', '\x83', 
		'\n', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', 
		'\b', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\v', 
		'\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x12', '\x3', '\x12', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', 
		'\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', 
		'\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', 
		'\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', 
		'\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', 
		'\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', 
		'\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', 
		'\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x5', 
		' ', '\x104', '\n', ' ', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '!', 
		'\x3', '!', '\x5', '!', '\x10B', '\n', '!', '\x3', '\"', '\x3', '\"', 
		'\x3', '#', '\x3', '#', '\x3', '$', '\x3', '$', '\x3', '%', '\x3', '%', 
		'\x3', '&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x3', '(', '\x3', '(', 
		'\x3', '(', '\x3', '(', '\x3', '(', '\x3', '(', '\x3', '(', '\x3', '(', 
		'\x3', '(', '\x3', '(', '\x3', '(', '\x3', '(', '\x5', '(', '\x125', '\n', 
		'(', '\x3', ')', '\x3', ')', '\x3', ')', '\x3', ')', '\x5', ')', '\x12B', 
		'\n', ')', '\x3', '*', '\x3', '*', '\x3', '+', '\x3', '+', '\x3', '+', 
		'\x3', '+', '\x3', '+', '\x3', '+', '\x3', '+', '\x3', ',', '\x3', ',', 
		'\x3', ',', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', ',', '\x3', '-', 
		'\x3', '-', '\x3', '-', '\x3', '-', '\x3', '-', '\x3', '.', '\x3', '.', 
		'\x3', '.', '\x3', '.', '\x3', '.', '\x3', '/', '\x3', '/', '\x3', '/', 
		'\x3', '/', '\x3', '/', '\x3', '\x30', '\x3', '\x30', '\x3', '\x30', '\x3', 
		'\x30', '\x3', '\x30', '\x3', '\x31', '\x3', '\x31', '\x3', '\x31', '\x3', 
		'\x31', '\x3', '\x31', '\x3', '\x31', '\x3', '\x32', '\x3', '\x32', '\x3', 
		'\x32', '\x3', '\x32', '\a', '\x32', '\x15B', '\n', '\x32', '\f', '\x32', 
		'\xE', '\x32', '\x15E', '\v', '\x32', '\x3', '\x33', '\x3', '\x33', '\a', 
		'\x33', '\x162', '\n', '\x33', '\f', '\x33', '\xE', '\x33', '\x165', '\v', 
		'\x33', '\x3', '\x34', '\x3', '\x34', '\x3', '\x35', '\x3', '\x35', '\a', 
		'\x35', '\x16B', '\n', '\x35', '\f', '\x35', '\xE', '\x35', '\x16E', '\v', 
		'\x35', '\x3', '\x36', '\x6', '\x36', '\x171', '\n', '\x36', '\r', '\x36', 
		'\xE', '\x36', '\x172', '\x3', '\x36', '\x3', '\x36', '\x6', '\x36', '\x177', 
		'\n', '\x36', '\r', '\x36', '\xE', '\x36', '\x178', '\x3', '\x37', '\x3', 
		'\x37', '\x5', '\x37', '\x17D', '\n', '\x37', '\x3', '\x38', '\x3', '\x38', 
		'\a', '\x38', '\x181', '\n', '\x38', '\f', '\x38', '\xE', '\x38', '\x184', 
		'\v', '\x38', '\x3', '\x38', '\x3', '\x38', '\x3', '\x39', '\x3', '\x39', 
		'\x3', '\x39', '\x3', '\x39', '\x3', ':', '\x3', ':', '\x3', ':', '\a', 
		':', '\x18F', '\n', ':', '\f', ':', '\xE', ':', '\x192', '\v', ':', '\x3', 
		':', '\x3', ':', '\x3', ';', '\x3', ';', '\x3', ';', '\a', ';', '\x199', 
		'\n', ';', '\f', ';', '\xE', ';', '\x19C', '\v', ';', '\x3', ';', '\x3', 
		';', '\x3', ';', '\x3', ';', '\x3', ';', '\x3', '<', '\x6', '<', '\x1A4', 
		'\n', '<', '\r', '<', '\xE', '<', '\x1A5', '\x3', '<', '\x3', '<', '\x3', 
		'\x19A', '\x2', '=', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', 
		'\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', 
		'\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', 
		'\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', 
		'+', '\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', '\x1B', 
		'\x35', '\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', ' ', 
		'?', '!', '\x41', '\"', '\x43', '#', '\x45', '$', 'G', '%', 'I', '&', 
		'K', '\'', 'M', '(', 'O', ')', 'Q', '*', 'S', '+', 'U', ',', 'W', '-', 
		'Y', '.', '[', '/', ']', '\x30', '_', '\x31', '\x61', '\x32', '\x63', 
		'\x33', '\x65', '\x2', 'g', '\x2', 'i', '\x34', 'k', '\x35', 'm', '\x36', 
		'o', '\x37', 'q', '\x38', 's', '\x39', 'u', ':', 'w', ';', '\x3', '\x2', 
		'\f', '\x4', '\x2', '>', '>', '@', '@', '\x4', '\x2', '-', '-', '/', '/', 
		'\x5', '\x2', '\'', '\'', ',', ',', '\x31', '\x31', '\x4', '\x2', '\x43', 
		'\\', '\x63', '|', '\x6', '\x2', '\x32', ';', '\x43', '\\', '\x61', '\x61', 
		'\x63', '|', '\x3', '\x2', '\x30', '\x30', '\x3', '\x2', '$', '$', '\x3', 
		'\x2', ')', ')', '\x4', '\x2', '\f', '\f', '\xF', '\xF', '\x5', '\x2', 
		'\v', '\f', '\xF', '\xF', '\"', '\"', '\x2', '\x1BA', '\x2', '\x3', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x2', '?', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x2', '\x45', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'G', '\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'K', '\x3', '\x2', '\x2', '\x2', '\x2', 'M', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'Q', '\x3', '\x2', '\x2', '\x2', '\x2', 'S', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'U', '\x3', '\x2', '\x2', '\x2', '\x2', 'W', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'Y', '\x3', '\x2', '\x2', '\x2', '\x2', '[', '\x3', '\x2', 
		'\x2', '\x2', '\x2', ']', '\x3', '\x2', '\x2', '\x2', '\x2', '_', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x61', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x63', '\x3', '\x2', '\x2', '\x2', '\x2', 'i', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'k', '\x3', '\x2', '\x2', '\x2', '\x2', 'm', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'o', '\x3', '\x2', '\x2', '\x2', '\x2', 'q', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 's', '\x3', '\x2', '\x2', '\x2', '\x2', 'u', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'w', '\x3', '\x2', '\x2', '\x2', '\x3', 'y', 
		'\x3', '\x2', '\x2', '\x2', '\x5', '~', '\x3', '\x2', '\x2', '\x2', '\a', 
		'\x82', '\x3', '\x2', '\x2', '\x2', '\t', '\x84', '\x3', '\x2', '\x2', 
		'\x2', '\v', '\x8D', '\x3', '\x2', '\x2', '\x2', '\r', '\x95', '\x3', 
		'\x2', '\x2', '\x2', '\xF', '\x9C', '\x3', '\x2', '\x2', '\x2', '\x11', 
		'\x9E', '\x3', '\x2', '\x2', '\x2', '\x13', '\xA0', '\x3', '\x2', '\x2', 
		'\x2', '\x15', '\xA2', '\x3', '\x2', '\x2', '\x2', '\x17', '\xA4', '\x3', 
		'\x2', '\x2', '\x2', '\x19', '\xA6', '\x3', '\x2', '\x2', '\x2', '\x1B', 
		'\xAE', '\x3', '\x2', '\x2', '\x2', '\x1D', '\xB4', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', '\xB8', '\x3', '\x2', '\x2', '\x2', '!', '\xBB', '\x3', 
		'\x2', '\x2', '\x2', '#', '\xC0', '\x3', '\x2', '\x2', '\x2', '%', '\xC5', 
		'\x3', '\x2', '\x2', '\x2', '\'', '\xC9', '\x3', '\x2', '\x2', '\x2', 
		')', '\xCF', '\x3', '\x2', '\x2', '\x2', '+', '\xD1', '\x3', '\x2', '\x2', 
		'\x2', '-', '\xD5', '\x3', '\x2', '\x2', '\x2', '/', '\xDA', '\x3', '\x2', 
		'\x2', '\x2', '\x31', '\xE2', '\x3', '\x2', '\x2', '\x2', '\x33', '\xE5', 
		'\x3', '\x2', '\x2', '\x2', '\x35', '\xEC', '\x3', '\x2', '\x2', '\x2', 
		'\x37', '\xF1', '\x3', '\x2', '\x2', '\x2', '\x39', '\xF7', '\x3', '\x2', 
		'\x2', '\x2', ';', '\xF9', '\x3', '\x2', '\x2', '\x2', '=', '\xFC', '\x3', 
		'\x2', '\x2', '\x2', '?', '\x103', '\x3', '\x2', '\x2', '\x2', '\x41', 
		'\x10A', '\x3', '\x2', '\x2', '\x2', '\x43', '\x10C', '\x3', '\x2', '\x2', 
		'\x2', '\x45', '\x10E', '\x3', '\x2', '\x2', '\x2', 'G', '\x110', '\x3', 
		'\x2', '\x2', '\x2', 'I', '\x112', '\x3', '\x2', '\x2', '\x2', 'K', '\x114', 
		'\x3', '\x2', '\x2', '\x2', 'M', '\x116', '\x3', '\x2', '\x2', '\x2', 
		'O', '\x124', '\x3', '\x2', '\x2', '\x2', 'Q', '\x12A', '\x3', '\x2', 
		'\x2', '\x2', 'S', '\x12C', '\x3', '\x2', '\x2', '\x2', 'U', '\x12E', 
		'\x3', '\x2', '\x2', '\x2', 'W', '\x135', '\x3', '\x2', '\x2', '\x2', 
		'Y', '\x13C', '\x3', '\x2', '\x2', '\x2', '[', '\x141', '\x3', '\x2', 
		'\x2', '\x2', ']', '\x146', '\x3', '\x2', '\x2', '\x2', '_', '\x14B', 
		'\x3', '\x2', '\x2', '\x2', '\x61', '\x150', '\x3', '\x2', '\x2', '\x2', 
		'\x63', '\x156', '\x3', '\x2', '\x2', '\x2', '\x65', '\x15F', '\x3', '\x2', 
		'\x2', '\x2', 'g', '\x166', '\x3', '\x2', '\x2', '\x2', 'i', '\x168', 
		'\x3', '\x2', '\x2', '\x2', 'k', '\x170', '\x3', '\x2', '\x2', '\x2', 
		'm', '\x17C', '\x3', '\x2', '\x2', '\x2', 'o', '\x17E', '\x3', '\x2', 
		'\x2', '\x2', 'q', '\x187', '\x3', '\x2', '\x2', '\x2', 's', '\x18B', 
		'\x3', '\x2', '\x2', '\x2', 'u', '\x195', '\x3', '\x2', '\x2', '\x2', 
		'w', '\x1A3', '\x3', '\x2', '\x2', '\x2', 'y', 'z', '\a', 'o', '\x2', 
		'\x2', 'z', '{', '\a', '\x63', '\x2', '\x2', '{', '|', '\a', 'k', '\x2', 
		'\x2', '|', '}', '\a', 'p', '\x2', '\x2', '}', '\x4', '\x3', '\x2', '\x2', 
		'\x2', '~', '\x7F', '\a', '\x41', '\x2', '\x2', '\x7F', '\x6', '\x3', 
		'\x2', '\x2', '\x2', '\x80', '\x83', '\x5', 'm', '\x37', '\x2', '\x81', 
		'\x83', '\x5', 'k', '\x36', '\x2', '\x82', '\x80', '\x3', '\x2', '\x2', 
		'\x2', '\x82', '\x81', '\x3', '\x2', '\x2', '\x2', '\x83', '\b', '\x3', 
		'\x2', '\x2', '\x2', '\x84', '\x85', '\a', 'h', '\x2', '\x2', '\x85', 
		'\x86', '\a', 'w', '\x2', '\x2', '\x86', '\x87', '\a', 'p', '\x2', '\x2', 
		'\x87', '\x88', '\a', '\x65', '\x2', '\x2', '\x88', '\x89', '\a', 'v', 
		'\x2', '\x2', '\x89', '\x8A', '\a', 'k', '\x2', '\x2', '\x8A', '\x8B', 
		'\a', 'q', '\x2', '\x2', '\x8B', '\x8C', '\a', 'p', '\x2', '\x2', '\x8C', 
		'\n', '\x3', '\x2', '\x2', '\x2', '\x8D', '\x8E', '\a', 't', '\x2', '\x2', 
		'\x8E', '\x8F', '\a', 'g', '\x2', '\x2', '\x8F', '\x90', '\a', 'v', '\x2', 
		'\x2', '\x90', '\x91', '\a', 'w', '\x2', '\x2', '\x91', '\x92', '\a', 
		't', '\x2', '\x2', '\x92', '\x93', '\a', 'p', '\x2', '\x2', '\x93', '\x94', 
		'\a', 'u', '\x2', '\x2', '\x94', '\f', '\x3', '\x2', '\x2', '\x2', '\x95', 
		'\x96', '\a', 't', '\x2', '\x2', '\x96', '\x97', '\a', 'g', '\x2', '\x2', 
		'\x97', '\x98', '\a', 'v', '\x2', '\x2', '\x98', '\x99', '\a', 'w', '\x2', 
		'\x2', '\x99', '\x9A', '\a', 't', '\x2', '\x2', '\x9A', '\x9B', '\a', 
		'p', '\x2', '\x2', '\x9B', '\xE', '\x3', '\x2', '\x2', '\x2', '\x9C', 
		'\x9D', '\a', '*', '\x2', '\x2', '\x9D', '\x10', '\x3', '\x2', '\x2', 
		'\x2', '\x9E', '\x9F', '\a', '+', '\x2', '\x2', '\x9F', '\x12', '\x3', 
		'\x2', '\x2', '\x2', '\xA0', '\xA1', '\a', '=', '\x2', '\x2', '\xA1', 
		'\x14', '\x3', '\x2', '\x2', '\x2', '\xA2', '\xA3', '\a', '?', '\x2', 
		'\x2', '\xA3', '\x16', '\x3', '\x2', '\x2', '\x2', '\xA4', '\xA5', '\a', 
		'.', '\x2', '\x2', '\xA5', '\x18', '\x3', '\x2', '\x2', '\x2', '\xA6', 
		'\xA7', '\a', 'k', '\x2', '\x2', '\xA7', '\xA8', '\a', 'p', '\x2', '\x2', 
		'\xA8', '\xA9', '\a', '\x65', '\x2', '\x2', '\xA9', '\xAA', '\a', 'n', 
		'\x2', '\x2', '\xAA', '\xAB', '\a', 'w', '\x2', '\x2', '\xAB', '\xAC', 
		'\a', '\x66', '\x2', '\x2', '\xAC', '\xAD', '\a', 'g', '\x2', '\x2', '\xAD', 
		'\x1A', '\x3', '\x2', '\x2', '\x2', '\xAE', '\xAF', '\a', '\x64', '\x2', 
		'\x2', '\xAF', '\xB0', '\a', 'g', '\x2', '\x2', '\xB0', '\xB1', '\a', 
		'i', '\x2', '\x2', '\xB1', '\xB2', '\a', 'k', '\x2', '\x2', '\xB2', '\xB3', 
		'\a', 'p', '\x2', '\x2', '\xB3', '\x1C', '\x3', '\x2', '\x2', '\x2', '\xB4', 
		'\xB5', '\a', 'g', '\x2', '\x2', '\xB5', '\xB6', '\a', 'p', '\x2', '\x2', 
		'\xB6', '\xB7', '\a', '\x66', '\x2', '\x2', '\xB7', '\x1E', '\x3', '\x2', 
		'\x2', '\x2', '\xB8', '\xB9', '\a', 'k', '\x2', '\x2', '\xB9', '\xBA', 
		'\a', 'h', '\x2', '\x2', '\xBA', ' ', '\x3', '\x2', '\x2', '\x2', '\xBB', 
		'\xBC', '\a', 'g', '\x2', '\x2', '\xBC', '\xBD', '\a', 'n', '\x2', '\x2', 
		'\xBD', '\xBE', '\a', 'u', '\x2', '\x2', '\xBE', '\xBF', '\a', 'g', '\x2', 
		'\x2', '\xBF', '\"', '\x3', '\x2', '\x2', '\x2', '\xC0', '\xC1', '\a', 
		'v', '\x2', '\x2', '\xC1', '\xC2', '\a', 'j', '\x2', '\x2', '\xC2', '\xC3', 
		'\a', 'g', '\x2', '\x2', '\xC3', '\xC4', '\a', 'p', '\x2', '\x2', '\xC4', 
		'$', '\x3', '\x2', '\x2', '\x2', '\xC5', '\xC6', '\a', 'h', '\x2', '\x2', 
		'\xC6', '\xC7', '\a', 'q', '\x2', '\x2', '\xC7', '\xC8', '\a', 't', '\x2', 
		'\x2', '\xC8', '&', '\x3', '\x2', '\x2', '\x2', '\xC9', '\xCA', '\a', 
		'y', '\x2', '\x2', '\xCA', '\xCB', '\a', 'j', '\x2', '\x2', '\xCB', '\xCC', 
		'\a', 'k', '\x2', '\x2', '\xCC', '\xCD', '\a', 'n', '\x2', '\x2', '\xCD', 
		'\xCE', '\a', 'g', '\x2', '\x2', '\xCE', '(', '\x3', '\x2', '\x2', '\x2', 
		'\xCF', '\xD0', '\a', '<', '\x2', '\x2', '\xD0', '*', '\x3', '\x2', '\x2', 
		'\x2', '\xD1', '\xD2', '\a', '\x30', '\x2', '\x2', '\xD2', '\xD3', '\a', 
		'\x30', '\x2', '\x2', '\xD3', '\xD4', '\a', '\x30', '\x2', '\x2', '\xD4', 
		',', '\x3', '\x2', '\x2', '\x2', '\xD5', '\xD6', '\a', 'u', '\x2', '\x2', 
		'\xD6', '\xD7', '\a', 'v', '\x2', '\x2', '\xD7', '\xD8', '\a', 'g', '\x2', 
		'\x2', '\xD8', '\xD9', '\a', 'r', '\x2', '\x2', '\xD9', '.', '\x3', '\x2', 
		'\x2', '\x2', '\xDA', '\xDB', '\a', 'h', '\x2', '\x2', '\xDB', '\xDC', 
		'\a', 'q', '\x2', '\x2', '\xDC', '\xDD', '\a', 't', '\x2', '\x2', '\xDD', 
		'\xDE', '\a', 'g', '\x2', '\x2', '\xDE', '\xDF', '\a', '\x63', '\x2', 
		'\x2', '\xDF', '\xE0', '\a', '\x65', '\x2', '\x2', '\xE0', '\xE1', '\a', 
		'j', '\x2', '\x2', '\xE1', '\x30', '\x3', '\x2', '\x2', '\x2', '\xE2', 
		'\xE3', '\a', 'k', '\x2', '\x2', '\xE3', '\xE4', '\a', 'p', '\x2', '\x2', 
		'\xE4', '\x32', '\x3', '\x2', '\x2', '\x2', '\xE5', '\xE6', '\a', 'u', 
		'\x2', '\x2', '\xE6', '\xE7', '\a', 'y', '\x2', '\x2', '\xE7', '\xE8', 
		'\a', 'k', '\x2', '\x2', '\xE8', '\xE9', '\a', 'v', '\x2', '\x2', '\xE9', 
		'\xEA', '\a', '\x65', '\x2', '\x2', '\xEA', '\xEB', '\a', 'j', '\x2', 
		'\x2', '\xEB', '\x34', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xED', '\a', 
		'\x65', '\x2', '\x2', '\xED', '\xEE', '\a', '\x63', '\x2', '\x2', '\xEE', 
		'\xEF', '\a', 'u', '\x2', '\x2', '\xEF', '\xF0', '\a', 'g', '\x2', '\x2', 
		'\xF0', '\x36', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xF2', '\a', '\x64', 
		'\x2', '\x2', '\xF2', '\xF3', '\a', 't', '\x2', '\x2', '\xF3', '\xF4', 
		'\a', 'g', '\x2', '\x2', '\xF4', '\xF5', '\a', '\x63', '\x2', '\x2', '\xF5', 
		'\xF6', '\a', 'm', '\x2', '\x2', '\xF6', '\x38', '\x3', '\x2', '\x2', 
		'\x2', '\xF7', '\xF8', '\a', '\x30', '\x2', '\x2', '\xF8', ':', '\x3', 
		'\x2', '\x2', '\x2', '\xF9', '\xFA', '\a', '~', '\x2', '\x2', '\xFA', 
		'\xFB', '\a', '~', '\x2', '\x2', '\xFB', '<', '\x3', '\x2', '\x2', '\x2', 
		'\xFC', '\xFD', '\a', '(', '\x2', '\x2', '\xFD', '\xFE', '\a', '(', '\x2', 
		'\x2', '\xFE', '>', '\x3', '\x2', '\x2', '\x2', '\xFF', '\x100', '\a', 
		'?', '\x2', '\x2', '\x100', '\x104', '\a', '?', '\x2', '\x2', '\x101', 
		'\x102', '\a', '#', '\x2', '\x2', '\x102', '\x104', '\a', '?', '\x2', 
		'\x2', '\x103', '\xFF', '\x3', '\x2', '\x2', '\x2', '\x103', '\x101', 
		'\x3', '\x2', '\x2', '\x2', '\x104', '@', '\x3', '\x2', '\x2', '\x2', 
		'\x105', '\x10B', '\t', '\x2', '\x2', '\x2', '\x106', '\x107', '\a', '>', 
		'\x2', '\x2', '\x107', '\x10B', '\a', '?', '\x2', '\x2', '\x108', '\x109', 
		'\a', '@', '\x2', '\x2', '\x109', '\x10B', '\a', '?', '\x2', '\x2', '\x10A', 
		'\x105', '\x3', '\x2', '\x2', '\x2', '\x10A', '\x106', '\x3', '\x2', '\x2', 
		'\x2', '\x10A', '\x108', '\x3', '\x2', '\x2', '\x2', '\x10B', '\x42', 
		'\x3', '\x2', '\x2', '\x2', '\x10C', '\x10D', '\t', '\x3', '\x2', '\x2', 
		'\x10D', '\x44', '\x3', '\x2', '\x2', '\x2', '\x10E', '\x10F', '\t', '\x4', 
		'\x2', '\x2', '\x10F', '\x46', '\x3', '\x2', '\x2', '\x2', '\x110', '\x111', 
		'\a', ']', '\x2', '\x2', '\x111', 'H', '\x3', '\x2', '\x2', '\x2', '\x112', 
		'\x113', '\a', '_', '\x2', '\x2', '\x113', 'J', '\x3', '\x2', '\x2', '\x2', 
		'\x114', '\x115', '\a', '}', '\x2', '\x2', '\x115', 'L', '\x3', '\x2', 
		'\x2', '\x2', '\x116', '\x117', '\a', '\x7F', '\x2', '\x2', '\x117', 'N', 
		'\x3', '\x2', '\x2', '\x2', '\x118', '\x119', '\a', ',', '\x2', '\x2', 
		'\x119', '\x125', '\a', '?', '\x2', '\x2', '\x11A', '\x11B', '\a', '\x31', 
		'\x2', '\x2', '\x11B', '\x125', '\a', '?', '\x2', '\x2', '\x11C', '\x11D', 
		'\a', '\'', '\x2', '\x2', '\x11D', '\x125', '\a', '?', '\x2', '\x2', '\x11E', 
		'\x11F', '\a', '-', '\x2', '\x2', '\x11F', '\x125', '\a', '?', '\x2', 
		'\x2', '\x120', '\x121', '\a', '/', '\x2', '\x2', '\x121', '\x125', '\a', 
		'?', '\x2', '\x2', '\x122', '\x123', '\a', '`', '\x2', '\x2', '\x123', 
		'\x125', '\a', '?', '\x2', '\x2', '\x124', '\x118', '\x3', '\x2', '\x2', 
		'\x2', '\x124', '\x11A', '\x3', '\x2', '\x2', '\x2', '\x124', '\x11C', 
		'\x3', '\x2', '\x2', '\x2', '\x124', '\x11E', '\x3', '\x2', '\x2', '\x2', 
		'\x124', '\x120', '\x3', '\x2', '\x2', '\x2', '\x124', '\x122', '\x3', 
		'\x2', '\x2', '\x2', '\x125', 'P', '\x3', '\x2', '\x2', '\x2', '\x126', 
		'\x127', '\a', '-', '\x2', '\x2', '\x127', '\x12B', '\a', '-', '\x2', 
		'\x2', '\x128', '\x129', '\a', '/', '\x2', '\x2', '\x129', '\x12B', '\a', 
		'/', '\x2', '\x2', '\x12A', '\x126', '\x3', '\x2', '\x2', '\x2', '\x12A', 
		'\x128', '\x3', '\x2', '\x2', '\x2', '\x12B', 'R', '\x3', '\x2', '\x2', 
		'\x2', '\x12C', '\x12D', '\a', '#', '\x2', '\x2', '\x12D', 'T', '\x3', 
		'\x2', '\x2', '\x2', '\x12E', '\x12F', '\a', 'p', '\x2', '\x2', '\x12F', 
		'\x130', '\a', 'w', '\x2', '\x2', '\x130', '\x131', '\a', 'o', '\x2', 
		'\x2', '\x131', '\x132', '\a', '\x64', '\x2', '\x2', '\x132', '\x133', 
		'\a', 'g', '\x2', '\x2', '\x133', '\x134', '\a', 't', '\x2', '\x2', '\x134', 
		'V', '\x3', '\x2', '\x2', '\x2', '\x135', '\x136', '\a', 'u', '\x2', '\x2', 
		'\x136', '\x137', '\a', 'v', '\x2', '\x2', '\x137', '\x138', '\a', 't', 
		'\x2', '\x2', '\x138', '\x139', '\a', 'k', '\x2', '\x2', '\x139', '\x13A', 
		'\a', 'p', '\x2', '\x2', '\x13A', '\x13B', '\a', 'i', '\x2', '\x2', '\x13B', 
		'X', '\x3', '\x2', '\x2', '\x2', '\x13C', '\x13D', '\a', '\x65', '\x2', 
		'\x2', '\x13D', '\x13E', '\a', 'j', '\x2', '\x2', '\x13E', '\x13F', '\a', 
		'\x63', '\x2', '\x2', '\x13F', '\x140', '\a', 't', '\x2', '\x2', '\x140', 
		'Z', '\x3', '\x2', '\x2', '\x2', '\x141', '\x142', '\a', '\x64', '\x2', 
		'\x2', '\x142', '\x143', '\a', 'q', '\x2', '\x2', '\x143', '\x144', '\a', 
		'q', '\x2', '\x2', '\x144', '\x145', '\a', 'n', '\x2', '\x2', '\x145', 
		'\\', '\x3', '\x2', '\x2', '\x2', '\x146', '\x147', '\a', 'x', '\x2', 
		'\x2', '\x147', '\x148', '\a', 'q', '\x2', '\x2', '\x148', '\x149', '\a', 
		'k', '\x2', '\x2', '\x149', '\x14A', '\a', '\x66', '\x2', '\x2', '\x14A', 
		'^', '\x3', '\x2', '\x2', '\x2', '\x14B', '\x14C', '\a', 'v', '\x2', '\x2', 
		'\x14C', '\x14D', '\a', 't', '\x2', '\x2', '\x14D', '\x14E', '\a', 'w', 
		'\x2', '\x2', '\x14E', '\x14F', '\a', 'g', '\x2', '\x2', '\x14F', '`', 
		'\x3', '\x2', '\x2', '\x2', '\x150', '\x151', '\a', 'h', '\x2', '\x2', 
		'\x151', '\x152', '\a', '\x63', '\x2', '\x2', '\x152', '\x153', '\a', 
		'n', '\x2', '\x2', '\x153', '\x154', '\a', 'u', '\x2', '\x2', '\x154', 
		'\x155', '\a', 'g', '\x2', '\x2', '\x155', '\x62', '\x3', '\x2', '\x2', 
		'\x2', '\x156', '\x15C', '\x5', '\x65', '\x33', '\x2', '\x157', '\x158', 
		'\x5', '\x39', '\x1D', '\x2', '\x158', '\x159', '\x5', '\x65', '\x33', 
		'\x2', '\x159', '\x15B', '\x3', '\x2', '\x2', '\x2', '\x15A', '\x157', 
		'\x3', '\x2', '\x2', '\x2', '\x15B', '\x15E', '\x3', '\x2', '\x2', '\x2', 
		'\x15C', '\x15A', '\x3', '\x2', '\x2', '\x2', '\x15C', '\x15D', '\x3', 
		'\x2', '\x2', '\x2', '\x15D', '\x64', '\x3', '\x2', '\x2', '\x2', '\x15E', 
		'\x15C', '\x3', '\x2', '\x2', '\x2', '\x15F', '\x163', '\t', '\x5', '\x2', 
		'\x2', '\x160', '\x162', '\t', '\x6', '\x2', '\x2', '\x161', '\x160', 
		'\x3', '\x2', '\x2', '\x2', '\x162', '\x165', '\x3', '\x2', '\x2', '\x2', 
		'\x163', '\x161', '\x3', '\x2', '\x2', '\x2', '\x163', '\x164', '\x3', 
		'\x2', '\x2', '\x2', '\x164', '\x66', '\x3', '\x2', '\x2', '\x2', '\x165', 
		'\x163', '\x3', '\x2', '\x2', '\x2', '\x166', '\x167', '\x4', '\x32', 
		';', '\x2', '\x167', 'h', '\x3', '\x2', '\x2', '\x2', '\x168', '\x16C', 
		'\x4', '\x33', ';', '\x2', '\x169', '\x16B', '\x5', 'g', '\x34', '\x2', 
		'\x16A', '\x169', '\x3', '\x2', '\x2', '\x2', '\x16B', '\x16E', '\x3', 
		'\x2', '\x2', '\x2', '\x16C', '\x16A', '\x3', '\x2', '\x2', '\x2', '\x16C', 
		'\x16D', '\x3', '\x2', '\x2', '\x2', '\x16D', 'j', '\x3', '\x2', '\x2', 
		'\x2', '\x16E', '\x16C', '\x3', '\x2', '\x2', '\x2', '\x16F', '\x171', 
		'\x5', 'g', '\x34', '\x2', '\x170', '\x16F', '\x3', '\x2', '\x2', '\x2', 
		'\x171', '\x172', '\x3', '\x2', '\x2', '\x2', '\x172', '\x170', '\x3', 
		'\x2', '\x2', '\x2', '\x172', '\x173', '\x3', '\x2', '\x2', '\x2', '\x173', 
		'\x174', '\x3', '\x2', '\x2', '\x2', '\x174', '\x176', '\t', '\a', '\x2', 
		'\x2', '\x175', '\x177', '\x5', 'g', '\x34', '\x2', '\x176', '\x175', 
		'\x3', '\x2', '\x2', '\x2', '\x177', '\x178', '\x3', '\x2', '\x2', '\x2', 
		'\x178', '\x176', '\x3', '\x2', '\x2', '\x2', '\x178', '\x179', '\x3', 
		'\x2', '\x2', '\x2', '\x179', 'l', '\x3', '\x2', '\x2', '\x2', '\x17A', 
		'\x17D', '\a', '\x32', '\x2', '\x2', '\x17B', '\x17D', '\x5', 'i', '\x35', 
		'\x2', '\x17C', '\x17A', '\x3', '\x2', '\x2', '\x2', '\x17C', '\x17B', 
		'\x3', '\x2', '\x2', '\x2', '\x17D', 'n', '\x3', '\x2', '\x2', '\x2', 
		'\x17E', '\x182', '\a', '$', '\x2', '\x2', '\x17F', '\x181', '\n', '\b', 
		'\x2', '\x2', '\x180', '\x17F', '\x3', '\x2', '\x2', '\x2', '\x181', '\x184', 
		'\x3', '\x2', '\x2', '\x2', '\x182', '\x180', '\x3', '\x2', '\x2', '\x2', 
		'\x182', '\x183', '\x3', '\x2', '\x2', '\x2', '\x183', '\x185', '\x3', 
		'\x2', '\x2', '\x2', '\x184', '\x182', '\x3', '\x2', '\x2', '\x2', '\x185', 
		'\x186', '\a', '$', '\x2', '\x2', '\x186', 'p', '\x3', '\x2', '\x2', '\x2', 
		'\x187', '\x188', '\a', ')', '\x2', '\x2', '\x188', '\x189', '\n', '\t', 
		'\x2', '\x2', '\x189', '\x18A', '\a', ')', '\x2', '\x2', '\x18A', 'r', 
		'\x3', '\x2', '\x2', '\x2', '\x18B', '\x18C', '\a', '\x31', '\x2', '\x2', 
		'\x18C', '\x190', '\a', '\x31', '\x2', '\x2', '\x18D', '\x18F', '\n', 
		'\n', '\x2', '\x2', '\x18E', '\x18D', '\x3', '\x2', '\x2', '\x2', '\x18F', 
		'\x192', '\x3', '\x2', '\x2', '\x2', '\x190', '\x18E', '\x3', '\x2', '\x2', 
		'\x2', '\x190', '\x191', '\x3', '\x2', '\x2', '\x2', '\x191', '\x193', 
		'\x3', '\x2', '\x2', '\x2', '\x192', '\x190', '\x3', '\x2', '\x2', '\x2', 
		'\x193', '\x194', '\b', ':', '\x2', '\x2', '\x194', 't', '\x3', '\x2', 
		'\x2', '\x2', '\x195', '\x196', '\a', '\x31', '\x2', '\x2', '\x196', '\x19A', 
		'\a', ',', '\x2', '\x2', '\x197', '\x199', '\v', '\x2', '\x2', '\x2', 
		'\x198', '\x197', '\x3', '\x2', '\x2', '\x2', '\x199', '\x19C', '\x3', 
		'\x2', '\x2', '\x2', '\x19A', '\x19B', '\x3', '\x2', '\x2', '\x2', '\x19A', 
		'\x198', '\x3', '\x2', '\x2', '\x2', '\x19B', '\x19D', '\x3', '\x2', '\x2', 
		'\x2', '\x19C', '\x19A', '\x3', '\x2', '\x2', '\x2', '\x19D', '\x19E', 
		'\a', ',', '\x2', '\x2', '\x19E', '\x19F', '\a', '\x31', '\x2', '\x2', 
		'\x19F', '\x1A0', '\x3', '\x2', '\x2', '\x2', '\x1A0', '\x1A1', '\b', 
		';', '\x2', '\x2', '\x1A1', 'v', '\x3', '\x2', '\x2', '\x2', '\x1A2', 
		'\x1A4', '\t', '\v', '\x2', '\x2', '\x1A3', '\x1A2', '\x3', '\x2', '\x2', 
		'\x2', '\x1A4', '\x1A5', '\x3', '\x2', '\x2', '\x2', '\x1A5', '\x1A3', 
		'\x3', '\x2', '\x2', '\x2', '\x1A5', '\x1A6', '\x3', '\x2', '\x2', '\x2', 
		'\x1A6', '\x1A7', '\x3', '\x2', '\x2', '\x2', '\x1A7', '\x1A8', '\b', 
		'<', '\x2', '\x2', '\x1A8', 'x', '\x3', '\x2', '\x2', '\x2', '\x12', '\x2', 
		'\x82', '\x103', '\x10A', '\x124', '\x12A', '\x15C', '\x163', '\x16C', 
		'\x172', '\x178', '\x17C', '\x182', '\x190', '\x19A', '\x1A5', '\x3', 
		'\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
