﻿using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using UniversalMarkdown.Parse.Elements;
using UITestMethodAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.AppContainer.UITestMethodAttribute;

namespace UniversalMarkdownUnitTests.Parse
{
    [TestClass]
    public class HyperlinkTests : ParseTestBase
    {
        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Http()
        {
            AssertEqual("http://reddit.com",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_WithSurroundingText()
        {
            AssertEqual("Narwhal http://reddit.com fail whale",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "Narwhal " },
                    new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl },
                    new TextRunInline { Text = " fail whale" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Http_Uppercase()
        {
            AssertEqual("HTTP://reddit.com",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Url = "HTTP://reddit.com", Text = "HTTP://reddit.com", LinkType = HyperlinkType.FullUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Http_Inline()
        {
            AssertEqual("The best site (http://reddit.com) goes well with http://www.wikipedia.com, don't you think?",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "The best site (" },
                    new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl },
                    new TextRunInline { Text = ") goes well with " },
                    new HyperlinkInline { Url = "http://www.wikipedia.com", Text = "http://www.wikipedia.com", LinkType = HyperlinkType.FullUrl },
                    new TextRunInline { Text = ", don't you think?" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Https()
        {
            AssertEqual("https://reddit.com",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Url = "https://reddit.com", Text = "https://reddit.com", LinkType = HyperlinkType.FullUrl }));
        }


        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_DomainOnly()
        {
            AssertEqual("www.reddit.com",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Url = "http://www.reddit.com", Text = "www.reddit.com", LinkType = HyperlinkType.PartialUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Mailto()
        {
            AssertEqual("bob@bob.com",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Url = "mailto:bob@bob.com", Text = "bob@bob.com", LinkType = HyperlinkType.Email }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_MailtoLocalPart()
        {
            AssertEqual(CollapseWhitespace(@"
                abcABC123@test.com

                a!b@test.com

                a#b@test.com

                a$b@test.com

                a%b@test.com

                a&b@test.com

                a*b@test.com

                a+b@test.com

                a!b@test.com

                a-b@test.com

                a=b@test.com

                a/b@test.com

                a?b@test.com

                a^b@test.com

                a_b@test.com

                a{b@test.com

                a}b@test.com

                a|b@test.com

                a!b@test.com

                a`b@test.com

                a'b@test.com

                a~b@test.com

                a.b@test.com

                a..b@test.com

                ab.@test.com

                .ab@test.com"),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:abcABC123@test.com", Text = "abcABC123@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a!" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a#" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a$" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a%" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a&" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a*" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:a+b@test.com", Text = "a+b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a!" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:a-b@test.com", Text = "a-b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a=" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a/" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a?" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a" }, new SuperscriptTextInline().AddChildren(new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email })),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:a_b@test.com", Text = "a_b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a{" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a}" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a|" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a!" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a`" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a'" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "a~" }, new HyperlinkInline { Url = "mailto:b@test.com", Text = "b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:a.b@test.com", Text = "a.b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:a..b@test.com", Text = "a..b@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:ab.@test.com", Text = "ab.@test.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:.ab@test.com", Text = ".ab@test.com", LinkType = HyperlinkType.Email }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_MailtoHostPart()
        {
            AssertEqual(CollapseWhitespace(@"
                abc@abcABC123.com

                abc@a!b.com

                abc@a#b.com

                abc@a$b.com

                abc@a%b.com

                abc@a&b.com

                abc@a*b.com

                abc@a+b.com

                abc@a!b.com

                abc@a-b.com

                abc@a=b.com

                abc@a/b.com

                abc@a?b.com

                abc@a^b.com

                abc@a_b.com

                abc@a{b.com

                abc@a}b.com

                abc@a|b.com

                abc@a!b.com

                abc@a`b.com

                abc@a'b.com

                abc@a~b.com

                abc@a.b.com

                abc@a..t.com

                abc@ab..com

                abc@.ab.com"),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:abc@abcABC123.com", Text = "abc@abcABC123.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a!b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a#b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a$b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a%b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a&b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a*b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a+b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a!b.com" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:abc@a-b.com", Text = "abc@a-b.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a=b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a/b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a?b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a" }, new SuperscriptTextInline().AddChildren(new TextRunInline { Text = "b.com" })),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:abc@a_b.com", Text = "abc@a_b.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a{b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a}b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a|b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a!b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a`b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a'b.com" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "abc@a~b.com" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:abc@a.b.com", Text = "abc@a.b.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:abc@a..t.com", Text = "abc@a..t.com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:abc@ab..com", Text = "abc@ab..com", LinkType = HyperlinkType.Email }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mailto:abc@.ab.com", Text = "abc@.ab.com", LinkType = HyperlinkType.Email }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_MailtoWithBold()
        {
            AssertEqual("abc__def@test.co__m",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "abc" },
                    new BoldTextInline().AddChildren(
                        new HyperlinkInline { Url = "mailto:def@test.co", Text = "def@test.co", LinkType = HyperlinkType.Email }),
                    new TextRunInline { Text = "m" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_AngleBrackets()
        {
            AssertEqual("<http://reddit.com>",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.BracketedUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_AngleBracketsNoNeedForDot()
        {
            AssertEqual("<http://reddit>",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Url = "http://reddit", Text = "http://reddit", LinkType = HyperlinkType.BracketedUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_AngleBracketsCanEndWithPunctuation()
        {
            AssertEqual("<http://reddit.com.>",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Url = "http://reddit.com.", Text = "http://reddit.com.", LinkType = HyperlinkType.BracketedUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_AngleBracketsCantHaveSpaces()
        {
            AssertEqual("< http://reddit.com >",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "< " },
                    new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl },
                    new TextRunInline { Text = " >" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_StartCharacters()
        {
            AssertEqual("0http://reddit.com",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "0" },
                    new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_EndCharacters()
        {
            AssertEqual(CollapseWhitespace(@"
                http://reddit.com)

                http://reddit.com).

                http://reddit.com)a

                http://reddit.com}

                http://reddit.com}a

                http://reddit.com]

                http://reddit.com]a

                http://reddit.com>

                http://reddit.com|

                http://reddit.com`

                http://reddit.com^

                http://reddit.com~

                http://reddit.com[

                http://reddit.com(

                http://reddit.com{

                http://reddit.com<

                http://reddit.com<a

                http://reddit.com#

                http://reddit.com%

                http://reddit.com!

                http://reddit.com!a

                http://reddit.com;

                http://reddit.com;a

                http://reddit.com.

                http://reddit.com.a

                http://reddit.com-

                http://reddit.com+

                http://reddit.com=

                http://reddit.com_

                http://reddit.com*

                http://reddit.com&

                http://reddit.com?

                http://reddit.com?a

                http://reddit.com,

                http://reddit.com,a"),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = ")" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = ")." }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com)a", Text = "http://reddit.com)a", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = "}" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com}a", Text = "http://reddit.com}a", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = "]" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com]a", Text = "http://reddit.com]a", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com>", Text = "http://reddit.com>", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com|", Text = "http://reddit.com|", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com`", Text = "http://reddit.com`", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com^", Text = "http://reddit.com^", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com~", Text = "http://reddit.com~", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com[", Text = "http://reddit.com[", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com(", Text = "http://reddit.com(", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com{", Text = "http://reddit.com{", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = "<" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = "<a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com#", Text = "http://reddit.com#", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com%", Text = "http://reddit.com%", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = "!" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com!a", Text = "http://reddit.com!a", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = ";" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com;a", Text = "http://reddit.com;a", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = "." }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com.a", Text = "http://reddit.com.a", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com-", Text = "http://reddit.com-", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com+", Text = "http://reddit.com+", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com=", Text = "http://reddit.com=", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com_", Text = "http://reddit.com_", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com*", Text = "http://reddit.com*", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com&", Text = "http://reddit.com&", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = "?" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com?a", Text = "http://reddit.com?a", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com", Text = "http://reddit.com", LinkType = HyperlinkType.FullUrl }, new TextRunInline { Text = "," }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://reddit.com,a", Text = "http://reddit.com,a", LinkType = HyperlinkType.FullUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_OtherSchemes()
        {
            AssertEqual(CollapseWhitespace(@"
                http://test.com

                https://test.com

                ftp://test.com

                steam://test.com

                irc://test.com

                news://test.com

                mumble://test.com

                ssh://test.com"),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "http://test.com", Text = "http://test.com", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "https://test.com", Text = "https://test.com", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "ftp://test.com", Text = "ftp://test.com", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "steam://test.com", Text = "steam://test.com", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "irc://test.com", Text = "irc://test.com", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "news://test.com", Text = "news://test.com", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "mumble://test.com", Text = "mumble://test.com", LinkType = HyperlinkType.FullUrl }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Url = "ssh://test.com", Text = "ssh://test.com", LinkType = HyperlinkType.FullUrl }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_SurroundingText()
        {
            AssertEqual("thttp://reddit.com",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "thttp://reddit.com" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_SchemeOnly()
        {
            AssertEqual("http:",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "http:" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_PrefixOnly()
        {
            AssertEqual("http://",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "http://" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_NoDot()
        {
            AssertEqual("http://localhost",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "http://localhost" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_DotTooSoon()
        {
            AssertEqual("http://.com",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "http://.com" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_AngleBracketsPrefixOnly()
        {
            AssertEqual("<http://>",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "<http://>" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_MailtoNeedsADot()
        {
            AssertEqual("bob@bob",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "bob@bob" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_AngleBracketDomainOnly()
        {
            AssertEqual("<www.reddit.com>",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "<www.reddit.com>" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Hyperlink_Negative_WwwMustBeLowercase()
        {
            AssertEqual("WWW.reddit.com",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "WWW.reddit.com" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_WithSlash()
        {
            AssertEqual("/r/subreddit",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Text = "/r/subreddit", Url = "/r/subreddit", LinkType = HyperlinkType.Subreddit }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_WithoutSlash()
        {
            AssertEqual("r/subreddit",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Text = "r/subreddit", Url = "/r/subreddit", LinkType = HyperlinkType.Subreddit }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_Short()
        {
            // Subreddit names can be min two chars long.
            AssertEqual("/r/ab",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Text = "/r/ab", Url = "/r/ab", LinkType = HyperlinkType.Subreddit }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_WithBeginningEscape()
        {
            AssertEqual(@"\/r/subreddit",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "/r/subreddit" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_WithMiddleEscape()
        {
            AssertEqual(@"r\/subreddit",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "r/subreddit" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_EndCharacters()
        {
            AssertEqual(CollapseWhitespace(@"
                /r/news)

                /r/news).

                /r/news)a

                /r/news}

                /r/news}a

                /r/news]

                /r/news]a

                /r/news>

                /r/news|

                /r/news`

                /r/news^

                /r/news~

                /r/news[

                /r/news(

                /r/news{

                /r/news<

                /r/news<a

                /r/news#

                /r/news%

                /r/news!

                /r/news!a

                /r/news;

                /r/news;a

                /r/news.

                /r/news.a

                /r/news-

                /r/news=

                /r/news_

                /r/news*

                /r/news&

                /r/news?

                /r/news?a

                /r/news,

                /r/news,a

                /r/news0"),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = ")" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = ")." }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = ")a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "}" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "}a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "]" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "]a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = ">" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "|" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "`" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "^" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "~" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "[" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "(" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "{" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "<" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "<a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "#" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "%" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "!" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "!a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = ";" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = ";a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "." }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = ".a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "-" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "=" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news_", Url = "/r/news_", LinkType = HyperlinkType.Subreddit }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "*" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "&" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "?" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "?a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = "," }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news", Url = "/r/news", LinkType = HyperlinkType.Subreddit }, new TextRunInline { Text = ",a" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/news0", Url = "/r/news0", LinkType = HyperlinkType.Subreddit }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_PlusCharacter()
        {
            // The plus character is treated strangely.
            AssertEqual(CollapseWhitespace(@"
                /r/+

                /r/+a

                /r/+ab

                /r/a+b

                /r/a+bc

                /r/ab+c

                /r/ab+cd

                /r/a+

                /r/ab+"),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "/r/+" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "/r/+a" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "/r/+ab" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "/r/a+b" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "/r/a+bc" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "/r/ab+c" }),
                new ParagraphBlock().AddChildren(new HyperlinkInline { Text = "/r/ab+cd", Url = "/r/ab+cd", LinkType = HyperlinkType.Subreddit }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "/r/a+" }),
                new ParagraphBlock().AddChildren(new TextRunInline { Text = "/r/ab+" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_WithPath()
        {
            AssertEqual("/r/news/blah",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Text = "/r/news/blah", Url = "/r/news/blah", LinkType = HyperlinkType.Subreddit }));
        }

        

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_Negative_SurroundingText()
        {
            AssertEqual("bear/subreddit",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "bear/subreddit" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_Negative_PrefixOnly()
        {
            AssertEqual("r/",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "r/" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_Negative_UppercaseWithoutSlash()
        {
            AssertEqual("R/baconit",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "R/baconit" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_Negative_UppercaseWithSlash()
        {
            AssertEqual("/R/baconit",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "/R/baconit" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void SubredditLink_Negative_TooShort()
        {
            // The subreddit name must be at least 2 chars.
            AssertEqual("r/a",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "r/a" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void UserLink_WithSlash()
        {
            AssertEqual("/u/quinbd",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Text = "/u/quinbd", Url = "/u/quinbd", LinkType = HyperlinkType.User }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void UserLink_WithoutSlash()
        {
            AssertEqual("u/quinbd",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Text = "u/quinbd", Url = "/u/quinbd", LinkType = HyperlinkType.User }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void UserLink_Short()
        {
            // User names can be one char long.
            AssertEqual("/u/u",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Text = "/u/u", Url = "/u/u", LinkType = HyperlinkType.User }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void UserLink_WithPath()
        {
            AssertEqual("/u/quinbd/blah",
                new ParagraphBlock().AddChildren(
                    new HyperlinkInline { Text = "/u/quinbd/blah", Url = "/u/quinbd/blah", LinkType = HyperlinkType.User }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void UserLink_Negative_PrefixOnly()
        {
            AssertEqual("u/",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "u/" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void UserLink_Negative_UppercaseWithoutSlash()
        {
            AssertEqual("U/quinbd",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "U/quinbd" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void UserLink_Negative_UppercaseWithSlash()
        {
            AssertEqual("/U/quinbd",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "/U/quinbd" }));
        }
    }
}
