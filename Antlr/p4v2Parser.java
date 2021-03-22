// Generated from p4v2.cfg by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class p4v2Parser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		Importstmts=1, InitStmts=2, Importstmt=3, Dcl=4, VarDcl=5, Modifier=6, 
		FuncDcl=7, Params=8, Param=9, Type=10, Body=11, Stmts=12, Expr=13, RelExpr=14, 
		AddExpr=15, MulExpr=16, Term=17, Val=18, ControlExpr=19, IfExpr=20, ElseExpr=21, 
		ForExpr=22, WhileExpr=23, ForeachExpr=24, SwitchExpr=25, Switchbody=26, 
		Cases=27, Case=28, Functioncall=29, Arguments=30, ReturnExpr=31, Size=32, 
		Id=33, Num=34, Integers=35, Decimal=36, RelOp=37, BoolOp=38, AddOp=39, 
		MulOp=40, Assignment=41, Function=42, Lbracket=43, Rbracket=44, Lparen=45, 
		Rparen=46, Return=47, Returns=48, Comma=49, Begin=50, End=51, If=52, Else=53, 
		Then=54, For=55, While=56, Colon=57, Dotdotdot=58, Step=59, Foreach=60, 
		In=61, Switch=62, CaseKeyword=63, Break=64, LineComment=65, MultiComment=66, 
		WS=67;
	public static final int
		RULE_s = 0;
	private static String[] makeRuleNames() {
		return new String[] {
			"s"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, "'='", "'function'", "'['", "']'", "'('", 
			"')'", "'return'", "'returns'", "','", "'begin'", "'end'", "'if'", "'else'", 
			"'then'", "'for'", "'while'", "':'", "'...'", "'step'", "'foreach'", 
			"'in'", "'switch'", "'case'", "'break'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "Importstmts", "InitStmts", "Importstmt", "Dcl", "VarDcl", "Modifier", 
			"FuncDcl", "Params", "Param", "Type", "Body", "Stmts", "Expr", "RelExpr", 
			"AddExpr", "MulExpr", "Term", "Val", "ControlExpr", "IfExpr", "ElseExpr", 
			"ForExpr", "WhileExpr", "ForeachExpr", "SwitchExpr", "Switchbody", "Cases", 
			"Case", "Functioncall", "Arguments", "ReturnExpr", "Size", "Id", "Num", 
			"Integers", "Decimal", "RelOp", "BoolOp", "AddOp", "MulOp", "Assignment", 
			"Function", "Lbracket", "Rbracket", "Lparen", "Rparen", "Return", "Returns", 
			"Comma", "Begin", "End", "If", "Else", "Then", "For", "While", "Colon", 
			"Dotdotdot", "Step", "Foreach", "In", "Switch", "CaseKeyword", "Break", 
			"LineComment", "MultiComment", "WS"
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

	@Override
	public String getGrammarFileName() { return "p4v2.cfg"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public p4v2Parser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class SContext extends ParserRuleContext {
		public TerminalNode Importstmts() { return getToken(p4v2Parser.Importstmts, 0); }
		public TerminalNode InitStmts() { return getToken(p4v2Parser.InitStmts, 0); }
		public SContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_s; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof p4v2Listener ) ((p4v2Listener)listener).enterS(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof p4v2Listener ) ((p4v2Listener)listener).exitS(this);
		}
	}

	public final SContext s() throws RecognitionException {
		SContext _localctx = new SContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_s);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(2);
			match(Importstmts);
			setState(3);
			match(InitStmts);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3E\b\4\2\t\2\3\2\3"+
		"\2\3\2\3\2\2\2\3\2\2\2\2\6\2\4\3\2\2\2\4\5\7\3\2\2\5\6\7\4\2\2\6\3\3\2"+
		"\2\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}