// Generated from d:\Github Repos\SAL\Antlr\p4.g4 by ANTLR 4.8
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class p4Lexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.8", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, Modifier=2, Number=3, Function=4, Returns=5, Return=6, Lparen=7, 
		Rparen=8, Semicolon=9, Assign=10, Comma=11, Include=12, Begin=13, End=14, 
		If=15, Else=16, Then=17, For=18, While=19, Colon=20, Dotdotdot=21, Step=22, 
		Foreach=23, In=24, Switch=25, CaseKeyword=26, Break=27, Dot=28, LogOrOp=29, 
		LogAndOp=30, EqualityOp=31, RelOp=32, AddOp=33, MultOp=34, Lbracket=35, 
		Rbracket=36, Lbrace=37, Rbrace=38, CompoundOp=39, IncrementOp=40, Negation=41, 
		NUMBER=42, STRING=43, CHAR=44, BOOL=45, VOID=46, True=47, False=48, Id=49, 
		Decimal=50, Integer=51, String=52, Char=53, LineComment=54, MultiComment=55, 
		WS=56;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "Modifier", "Number", "Function", "Returns", "Return", "Lparen", 
			"Rparen", "Semicolon", "Assign", "Comma", "Include", "Begin", "End", 
			"If", "Else", "Then", "For", "While", "Colon", "Dotdotdot", "Step", "Foreach", 
			"In", "Switch", "CaseKeyword", "Break", "Dot", "LogOrOp", "LogAndOp", 
			"EqualityOp", "RelOp", "AddOp", "MultOp", "Lbracket", "Rbracket", "Lbrace", 
			"Rbrace", "CompoundOp", "IncrementOp", "Negation", "NUMBER", "STRING", 
			"CHAR", "BOOL", "VOID", "True", "False", "Id", "Digit", "Nonzero", "Decimal", 
			"Integer", "String", "Char", "LineComment", "MultiComment", "WS"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'?'", null, null, "'function'", "'returns'", "'return'", "'('", 
			"')'", "';'", "'='", "','", "'include'", "'begin'", "'end'", "'if'", 
			"'else'", "'then'", "'for'", "'while'", "':'", "'...'", "'step'", "'foreach'", 
			"'in'", "'switch'", "'case'", "'break'", "'.'", "'||'", "'&&'", null, 
			null, null, null, "'['", "']'", "'{'", "'}'", null, null, "'!'", "'number'", 
			"'string'", "'char'", "'bool'", "'void'", "'true'", "'false'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, "Modifier", "Number", "Function", "Returns", "Return", "Lparen", 
			"Rparen", "Semicolon", "Assign", "Comma", "Include", "Begin", "End", 
			"If", "Else", "Then", "For", "While", "Colon", "Dotdotdot", "Step", "Foreach", 
			"In", "Switch", "CaseKeyword", "Break", "Dot", "LogOrOp", "LogAndOp", 
			"EqualityOp", "RelOp", "AddOp", "MultOp", "Lbracket", "Rbracket", "Lbrace", 
			"Rbrace", "CompoundOp", "IncrementOp", "Negation", "NUMBER", "STRING", 
			"CHAR", "BOOL", "VOID", "True", "False", "Id", "Decimal", "Integer", 
			"String", "Char", "LineComment", "MultiComment", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public p4Lexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "p4.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2:\u019f\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\3\2\3\2\3\3"+
		"\3\3\5\3|\n\3\3\3\3\3\3\4\3\4\5\4\u0082\n\4\3\5\3\5\3\5\3\5\3\5\3\5\3"+
		"\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3\7"+
		"\3\b\3\b\3\t\3\t\3\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r"+
		"\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\20\3\20\3\20"+
		"\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\22\3\22\3\22\3\23\3\23\3\23\3\23"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\25\3\25\3\26\3\26\3\26\3\26\3\27\3\27"+
		"\3\27\3\27\3\27\3\30\3\30\3\30\3\30\3\30\3\30\3\30\3\30\3\31\3\31\3\31"+
		"\3\32\3\32\3\32\3\32\3\32\3\32\3\32\3\33\3\33\3\33\3\33\3\33\3\34\3\34"+
		"\3\34\3\34\3\34\3\34\3\35\3\35\3\36\3\36\3\36\3\37\3\37\3\37\3 \3 \3 "+
		"\3 \5 \u0103\n \3!\3!\3!\3!\3!\5!\u010a\n!\3\"\3\"\3#\3#\3$\3$\3%\3%\3"+
		"&\3&\3\'\3\'\3(\3(\3(\3(\3(\3(\3(\3(\3(\3(\3(\3(\5(\u0124\n(\3)\3)\3)"+
		"\3)\5)\u012a\n)\3*\3*\3+\3+\3+\3+\3+\3+\3+\3,\3,\3,\3,\3,\3,\3,\3-\3-"+
		"\3-\3-\3-\3.\3.\3.\3.\3.\3/\3/\3/\3/\3/\3\60\3\60\3\60\3\60\3\60\3\61"+
		"\3\61\3\61\3\61\3\61\3\61\3\62\3\62\7\62\u0158\n\62\f\62\16\62\u015b\13"+
		"\62\3\63\3\63\3\64\3\64\7\64\u0161\n\64\f\64\16\64\u0164\13\64\3\65\6"+
		"\65\u0167\n\65\r\65\16\65\u0168\3\65\3\65\6\65\u016d\n\65\r\65\16\65\u016e"+
		"\3\66\3\66\5\66\u0173\n\66\3\67\3\67\7\67\u0177\n\67\f\67\16\67\u017a"+
		"\13\67\3\67\3\67\38\38\38\38\39\39\39\79\u0185\n9\f9\169\u0188\139\39"+
		"\39\3:\3:\3:\7:\u018f\n:\f:\16:\u0192\13:\3:\3:\3:\3:\3:\3;\6;\u019a\n"+
		";\r;\16;\u019b\3;\3;\3\u0190\2<\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23"+
		"\13\25\f\27\r\31\16\33\17\35\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31"+
		"\61\32\63\33\65\34\67\359\36;\37= ?!A\"C#E$G%I&K\'M(O)Q*S+U,W-Y.[/]\60"+
		"_\61a\62c\63e\2g\2i\64k\65m\66o\67q8s9u:\3\2\f\4\2>>@@\4\2--//\5\2\'\'"+
		",,\61\61\4\2C\\c|\6\2\62;C\\aac|\3\2\60\60\3\2$$\3\2))\4\2\f\f\17\17\5"+
		"\2\13\f\17\17\"\"\2\u01b0\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2"+
		"\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2"+
		"\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2\2\37\3"+
		"\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2"+
		"\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67"+
		"\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2"+
		"\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2"+
		"\2Q\3\2\2\2\2S\3\2\2\2\2U\3\2\2\2\2W\3\2\2\2\2Y\3\2\2\2\2[\3\2\2\2\2]"+
		"\3\2\2\2\2_\3\2\2\2\2a\3\2\2\2\2c\3\2\2\2\2i\3\2\2\2\2k\3\2\2\2\2m\3\2"+
		"\2\2\2o\3\2\2\2\2q\3\2\2\2\2s\3\2\2\2\2u\3\2\2\2\3w\3\2\2\2\5y\3\2\2\2"+
		"\7\u0081\3\2\2\2\t\u0083\3\2\2\2\13\u008c\3\2\2\2\r\u0094\3\2\2\2\17\u009b"+
		"\3\2\2\2\21\u009d\3\2\2\2\23\u009f\3\2\2\2\25\u00a1\3\2\2\2\27\u00a3\3"+
		"\2\2\2\31\u00a5\3\2\2\2\33\u00ad\3\2\2\2\35\u00b3\3\2\2\2\37\u00b7\3\2"+
		"\2\2!\u00ba\3\2\2\2#\u00bf\3\2\2\2%\u00c4\3\2\2\2\'\u00c8\3\2\2\2)\u00ce"+
		"\3\2\2\2+\u00d0\3\2\2\2-\u00d4\3\2\2\2/\u00d9\3\2\2\2\61\u00e1\3\2\2\2"+
		"\63\u00e4\3\2\2\2\65\u00eb\3\2\2\2\67\u00f0\3\2\2\29\u00f6\3\2\2\2;\u00f8"+
		"\3\2\2\2=\u00fb\3\2\2\2?\u0102\3\2\2\2A\u0109\3\2\2\2C\u010b\3\2\2\2E"+
		"\u010d\3\2\2\2G\u010f\3\2\2\2I\u0111\3\2\2\2K\u0113\3\2\2\2M\u0115\3\2"+
		"\2\2O\u0123\3\2\2\2Q\u0129\3\2\2\2S\u012b\3\2\2\2U\u012d\3\2\2\2W\u0134"+
		"\3\2\2\2Y\u013b\3\2\2\2[\u0140\3\2\2\2]\u0145\3\2\2\2_\u014a\3\2\2\2a"+
		"\u014f\3\2\2\2c\u0155\3\2\2\2e\u015c\3\2\2\2g\u015e\3\2\2\2i\u0166\3\2"+
		"\2\2k\u0172\3\2\2\2m\u0174\3\2\2\2o\u017d\3\2\2\2q\u0181\3\2\2\2s\u018b"+
		"\3\2\2\2u\u0199\3\2\2\2wx\7A\2\2x\4\3\2\2\2y{\5G$\2z|\5g\64\2{z\3\2\2"+
		"\2{|\3\2\2\2|}\3\2\2\2}~\5I%\2~\6\3\2\2\2\177\u0082\5k\66\2\u0080\u0082"+
		"\5i\65\2\u0081\177\3\2\2\2\u0081\u0080\3\2\2\2\u0082\b\3\2\2\2\u0083\u0084"+
		"\7h\2\2\u0084\u0085\7w\2\2\u0085\u0086\7p\2\2\u0086\u0087\7e\2\2\u0087"+
		"\u0088\7v\2\2\u0088\u0089\7k\2\2\u0089\u008a\7q\2\2\u008a\u008b\7p\2\2"+
		"\u008b\n\3\2\2\2\u008c\u008d\7t\2\2\u008d\u008e\7g\2\2\u008e\u008f\7v"+
		"\2\2\u008f\u0090\7w\2\2\u0090\u0091\7t\2\2\u0091\u0092\7p\2\2\u0092\u0093"+
		"\7u\2\2\u0093\f\3\2\2\2\u0094\u0095\7t\2\2\u0095\u0096\7g\2\2\u0096\u0097"+
		"\7v\2\2\u0097\u0098\7w\2\2\u0098\u0099\7t\2\2\u0099\u009a\7p\2\2\u009a"+
		"\16\3\2\2\2\u009b\u009c\7*\2\2\u009c\20\3\2\2\2\u009d\u009e\7+\2\2\u009e"+
		"\22\3\2\2\2\u009f\u00a0\7=\2\2\u00a0\24\3\2\2\2\u00a1\u00a2\7?\2\2\u00a2"+
		"\26\3\2\2\2\u00a3\u00a4\7.\2\2\u00a4\30\3\2\2\2\u00a5\u00a6\7k\2\2\u00a6"+
		"\u00a7\7p\2\2\u00a7\u00a8\7e\2\2\u00a8\u00a9\7n\2\2\u00a9\u00aa\7w\2\2"+
		"\u00aa\u00ab\7f\2\2\u00ab\u00ac\7g\2\2\u00ac\32\3\2\2\2\u00ad\u00ae\7"+
		"d\2\2\u00ae\u00af\7g\2\2\u00af\u00b0\7i\2\2\u00b0\u00b1\7k\2\2\u00b1\u00b2"+
		"\7p\2\2\u00b2\34\3\2\2\2\u00b3\u00b4\7g\2\2\u00b4\u00b5\7p\2\2\u00b5\u00b6"+
		"\7f\2\2\u00b6\36\3\2\2\2\u00b7\u00b8\7k\2\2\u00b8\u00b9\7h\2\2\u00b9 "+
		"\3\2\2\2\u00ba\u00bb\7g\2\2\u00bb\u00bc\7n\2\2\u00bc\u00bd\7u\2\2\u00bd"+
		"\u00be\7g\2\2\u00be\"\3\2\2\2\u00bf\u00c0\7v\2\2\u00c0\u00c1\7j\2\2\u00c1"+
		"\u00c2\7g\2\2\u00c2\u00c3\7p\2\2\u00c3$\3\2\2\2\u00c4\u00c5\7h\2\2\u00c5"+
		"\u00c6\7q\2\2\u00c6\u00c7\7t\2\2\u00c7&\3\2\2\2\u00c8\u00c9\7y\2\2\u00c9"+
		"\u00ca\7j\2\2\u00ca\u00cb\7k\2\2\u00cb\u00cc\7n\2\2\u00cc\u00cd\7g\2\2"+
		"\u00cd(\3\2\2\2\u00ce\u00cf\7<\2\2\u00cf*\3\2\2\2\u00d0\u00d1\7\60\2\2"+
		"\u00d1\u00d2\7\60\2\2\u00d2\u00d3\7\60\2\2\u00d3,\3\2\2\2\u00d4\u00d5"+
		"\7u\2\2\u00d5\u00d6\7v\2\2\u00d6\u00d7\7g\2\2\u00d7\u00d8\7r\2\2\u00d8"+
		".\3\2\2\2\u00d9\u00da\7h\2\2\u00da\u00db\7q\2\2\u00db\u00dc\7t\2\2\u00dc"+
		"\u00dd\7g\2\2\u00dd\u00de\7c\2\2\u00de\u00df\7e\2\2\u00df\u00e0\7j\2\2"+
		"\u00e0\60\3\2\2\2\u00e1\u00e2\7k\2\2\u00e2\u00e3\7p\2\2\u00e3\62\3\2\2"+
		"\2\u00e4\u00e5\7u\2\2\u00e5\u00e6\7y\2\2\u00e6\u00e7\7k\2\2\u00e7\u00e8"+
		"\7v\2\2\u00e8\u00e9\7e\2\2\u00e9\u00ea\7j\2\2\u00ea\64\3\2\2\2\u00eb\u00ec"+
		"\7e\2\2\u00ec\u00ed\7c\2\2\u00ed\u00ee\7u\2\2\u00ee\u00ef\7g\2\2\u00ef"+
		"\66\3\2\2\2\u00f0\u00f1\7d\2\2\u00f1\u00f2\7t\2\2\u00f2\u00f3\7g\2\2\u00f3"+
		"\u00f4\7c\2\2\u00f4\u00f5\7m\2\2\u00f58\3\2\2\2\u00f6\u00f7\7\60\2\2\u00f7"+
		":\3\2\2\2\u00f8\u00f9\7~\2\2\u00f9\u00fa\7~\2\2\u00fa<\3\2\2\2\u00fb\u00fc"+
		"\7(\2\2\u00fc\u00fd\7(\2\2\u00fd>\3\2\2\2\u00fe\u00ff\7?\2\2\u00ff\u0103"+
		"\7?\2\2\u0100\u0101\7#\2\2\u0101\u0103\7?\2\2\u0102\u00fe\3\2\2\2\u0102"+
		"\u0100\3\2\2\2\u0103@\3\2\2\2\u0104\u010a\t\2\2\2\u0105\u0106\7>\2\2\u0106"+
		"\u010a\7?\2\2\u0107\u0108\7@\2\2\u0108\u010a\7?\2\2\u0109\u0104\3\2\2"+
		"\2\u0109\u0105\3\2\2\2\u0109\u0107\3\2\2\2\u010aB\3\2\2\2\u010b\u010c"+
		"\t\3\2\2\u010cD\3\2\2\2\u010d\u010e\t\4\2\2\u010eF\3\2\2\2\u010f\u0110"+
		"\7]\2\2\u0110H\3\2\2\2\u0111\u0112\7_\2\2\u0112J\3\2\2\2\u0113\u0114\7"+
		"}\2\2\u0114L\3\2\2\2\u0115\u0116\7\177\2\2\u0116N\3\2\2\2\u0117\u0118"+
		"\7,\2\2\u0118\u0124\7?\2\2\u0119\u011a\7\61\2\2\u011a\u0124\7?\2\2\u011b"+
		"\u011c\7\'\2\2\u011c\u0124\7?\2\2\u011d\u011e\7-\2\2\u011e\u0124\7?\2"+
		"\2\u011f\u0120\7/\2\2\u0120\u0124\7?\2\2\u0121\u0122\7`\2\2\u0122\u0124"+
		"\7?\2\2\u0123\u0117\3\2\2\2\u0123\u0119\3\2\2\2\u0123\u011b\3\2\2\2\u0123"+
		"\u011d\3\2\2\2\u0123\u011f\3\2\2\2\u0123\u0121\3\2\2\2\u0124P\3\2\2\2"+
		"\u0125\u0126\7-\2\2\u0126\u012a\7-\2\2\u0127\u0128\7/\2\2\u0128\u012a"+
		"\7/\2\2\u0129\u0125\3\2\2\2\u0129\u0127\3\2\2\2\u012aR\3\2\2\2\u012b\u012c"+
		"\7#\2\2\u012cT\3\2\2\2\u012d\u012e\7p\2\2\u012e\u012f\7w\2\2\u012f\u0130"+
		"\7o\2\2\u0130\u0131\7d\2\2\u0131\u0132\7g\2\2\u0132\u0133\7t\2\2\u0133"+
		"V\3\2\2\2\u0134\u0135\7u\2\2\u0135\u0136\7v\2\2\u0136\u0137\7t\2\2\u0137"+
		"\u0138\7k\2\2\u0138\u0139\7p\2\2\u0139\u013a\7i\2\2\u013aX\3\2\2\2\u013b"+
		"\u013c\7e\2\2\u013c\u013d\7j\2\2\u013d\u013e\7c\2\2\u013e\u013f\7t\2\2"+
		"\u013fZ\3\2\2\2\u0140\u0141\7d\2\2\u0141\u0142\7q\2\2\u0142\u0143\7q\2"+
		"\2\u0143\u0144\7n\2\2\u0144\\\3\2\2\2\u0145\u0146\7x\2\2\u0146\u0147\7"+
		"q\2\2\u0147\u0148\7k\2\2\u0148\u0149\7f\2\2\u0149^\3\2\2\2\u014a\u014b"+
		"\7v\2\2\u014b\u014c\7t\2\2\u014c\u014d\7w\2\2\u014d\u014e\7g\2\2\u014e"+
		"`\3\2\2\2\u014f\u0150\7h\2\2\u0150\u0151\7c\2\2\u0151\u0152\7n\2\2\u0152"+
		"\u0153\7u\2\2\u0153\u0154\7g\2\2\u0154b\3\2\2\2\u0155\u0159\t\5\2\2\u0156"+
		"\u0158\t\6\2\2\u0157\u0156\3\2\2\2\u0158\u015b\3\2\2\2\u0159\u0157\3\2"+
		"\2\2\u0159\u015a\3\2\2\2\u015ad\3\2\2\2\u015b\u0159\3\2\2\2\u015c\u015d"+
		"\4\62;\2\u015df\3\2\2\2\u015e\u0162\4\63;\2\u015f\u0161\5e\63\2\u0160"+
		"\u015f\3\2\2\2\u0161\u0164\3\2\2\2\u0162\u0160\3\2\2\2\u0162\u0163\3\2"+
		"\2\2\u0163h\3\2\2\2\u0164\u0162\3\2\2\2\u0165\u0167\5e\63\2\u0166\u0165"+
		"\3\2\2\2\u0167\u0168\3\2\2\2\u0168\u0166\3\2\2\2\u0168\u0169\3\2\2\2\u0169"+
		"\u016a\3\2\2\2\u016a\u016c\t\7\2\2\u016b\u016d\5e\63\2\u016c\u016b\3\2"+
		"\2\2\u016d\u016e\3\2\2\2\u016e\u016c\3\2\2\2\u016e\u016f\3\2\2\2\u016f"+
		"j\3\2\2\2\u0170\u0173\7\62\2\2\u0171\u0173\5g\64\2\u0172\u0170\3\2\2\2"+
		"\u0172\u0171\3\2\2\2\u0173l\3\2\2\2\u0174\u0178\7$\2\2\u0175\u0177\n\b"+
		"\2\2\u0176\u0175\3\2\2\2\u0177\u017a\3\2\2\2\u0178\u0176\3\2\2\2\u0178"+
		"\u0179\3\2\2\2\u0179\u017b\3\2\2\2\u017a\u0178\3\2\2\2\u017b\u017c\7$"+
		"\2\2\u017cn\3\2\2\2\u017d\u017e\7)\2\2\u017e\u017f\n\t\2\2\u017f\u0180"+
		"\7)\2\2\u0180p\3\2\2\2\u0181\u0182\7\61\2\2\u0182\u0186\7\61\2\2\u0183"+
		"\u0185\n\n\2\2\u0184\u0183\3\2\2\2\u0185\u0188\3\2\2\2\u0186\u0184\3\2"+
		"\2\2\u0186\u0187\3\2\2\2\u0187\u0189\3\2\2\2\u0188\u0186\3\2\2\2\u0189"+
		"\u018a\b9\2\2\u018ar\3\2\2\2\u018b\u018c\7\61\2\2\u018c\u0190\7,\2\2\u018d"+
		"\u018f\13\2\2\2\u018e\u018d\3\2\2\2\u018f\u0192\3\2\2\2\u0190\u0191\3"+
		"\2\2\2\u0190\u018e\3\2\2\2\u0191\u0193\3\2\2\2\u0192\u0190\3\2\2\2\u0193"+
		"\u0194\7,\2\2\u0194\u0195\7\61\2\2\u0195\u0196\3\2\2\2\u0196\u0197\b:"+
		"\2\2\u0197t\3\2\2\2\u0198\u019a\t\13\2\2\u0199\u0198\3\2\2\2\u019a\u019b"+
		"\3\2\2\2\u019b\u0199\3\2\2\2\u019b\u019c\3\2\2\2\u019c\u019d\3\2\2\2\u019d"+
		"\u019e\b;\2\2\u019ev\3\2\2\2\22\2{\u0081\u0102\u0109\u0123\u0129\u0159"+
		"\u0162\u0168\u016e\u0172\u0178\u0186\u0190\u019b\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}