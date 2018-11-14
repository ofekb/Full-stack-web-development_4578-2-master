# Git commands 

## Basic config
* update user daetails global:
```bash
$ git config --global user.name <"NAME">
$ git config --global user.email <"EMAIL">
git config --list 
```
* show the git config content with this command:
```bash
cat .gitconfig 
```
* ask git for help
```bash
git --help
git help <"COMMAND">
```

## First git project
```bash
mkdir test  # craete new folder named test

cd test   # change current path to the folder that we created in prev step

ls -a  # show all folder content
./  ../

git init  # Initialized empty Git repository 
Initialized empty Git repository in C:/Users/administrator.NB/test/.git/

ls -a     # show all folder content
./  ../  .git/

touch first.txt   # create a new fike named first.txt

ls -a    # show all folder content
./  ../  .git/  first.txt

echo "test1" > first.txt   # write into first.txt file "test1"

cat first.txt  # show first.txt file content
test1

git status   # command to check untracked / uncommited parts
On branch master
No commits yet
Untracked files:
  (use "git add <file>..." to include in what will be committed)
        first.txt

nothing added to commit but untracked files present (use "git add" to track)

git add . # add to stage all changes that are untracked

git status    # command to check untracked / uncommited parts
On branch master
No commits yet
Changes to be committed:
  (use "git rm --cached <file>..." to unstage)
        new file:   first.txt

git commit -m "first commit"  # record changes to the repository
[master (root-commit) ba3173a] first commit
 1 file changed, 1 insertion(+)
 create mode 100644 first.txt

git status      # command to check untracked / uncommited parts
On branch master
nothing to commit, working tree clean


git log
commit ba3173a7e518f4cc4f32db669fce855d3dacd99d (HEAD -> master)
Author: AnnaKarpf <32166631+AnnaKarpf@users.noreply.github.com>
Date:   Mon Aug 20 11:46:07 2018 +0300
    first commit

echo "test2" > first.txt

git status
On branch master
Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)
        modified:   first.txt
no changes added to commit (use "git add" and/or "git commit -a")

git diff
diff --git a/first.txt b/first.txt
index a5bce3f..180cf83 100644
--- a/first.txt
+++ b/first.txt
@@ -1 +1 @@
-test1
+test2

git add .

git commit -m "second commit"
[master f806cb8] second commit
 1 file changed, 1 insertion(+), 1 deletion(-)


git status
On branch master
nothing to commit, working tree clean

git log
commit f806cb88cb9519db275c4a5e7006908bdb817699 (HEAD -> master)
Author: AnnaKarpf <32166631+AnnaKarpf@users.noreply.github.com>
Date:   Mon Aug 20 14:01:11 2018 +0300
    second commit

commit ba3173a7e518f4cc4f32db669fce855d3dacd99d
Author: AnnaKarpf <32166631+AnnaKarpf@users.noreply.github.com>
Date:   Mon Aug 20 11:46:07 2018 +0300
    first commit

$ touch second.txt

Administrator@NB16 MINGW64 ~/test (master)
$ echo "exam1" > second.txt

Administrator@NB16 MINGW64 ~/test (master)
$ git status
On branch master
Untracked files:
  (use "git add <file>..." to include in what will be committed)

        second.txt

nothing added to commit but untracked files present (use "git add" to track)


$ echo "test3" >> first.txt

Administrator@NB16 MINGW64 ~/test (master)
$ cat first.txt
test2
test3

Administrator@NB16 MINGW64 ~/test (master)
$ cat second.txt
exam1

Administrator@NB16 MINGW64 ~/test (master)
$ git status
On branch master
Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   first.txt

Untracked files:
  (use "git add <file>..." to include in what will be committed)

        second.txt

no changes added to commit (use "git add" and/or "git commit -a")

Administrator@NB16 MINGW64 ~/test (master)
$ git add second.txt
warning: LF will be replaced by CRLF in second.txt.
The file will have its original line endings in your working directory.

Administrator@NB16 MINGW64 ~/test (master)
$ git status
On branch master
Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        new file:   second.txt

Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   first.txt


Administrator@NB16 MINGW64 ~/test (master)
$ git commit -m "third commit"
[master 3636864] third commit
 1 file changed, 1 insertion(+)
 create mode 100644 second.txt

Administrator@NB16 MINGW64 ~/test (master)
$ git status
On branch master
Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   first.txt

no changes added to commit (use "git add" and/or "git commit -a")

Administrator@NB16 MINGW64 ~/test (master)
$ git log
commit 3636864e8e73267272a68c269e0eed857c8bcb9f (HEAD -> master)
Author: AnnaKarpf <32166631+AnnaKarpf@users.noreply.github.com>
Date:   Mon Aug 20 14:07:41 2018 +0300

    third commit

commit f806cb88cb9519db275c4a5e7006908bdb817699
Author: AnnaKarpf <32166631+AnnaKarpf@users.noreply.github.com>
Date:   Mon Aug 20 14:01:11 2018 +0300

    second commit

commit ba3173a7e518f4cc4f32db669fce855d3dacd99d
Author: AnnaKarpf <32166631+AnnaKarpf@users.noreply.github.com>
Date:   Mon Aug 20 11:46:07 2018 +0300

    first commit

Administrator@NB16 MINGW64 ~/test (master)
$ git rm second.txt
rm 'second.txt'

Administrator@NB16 MINGW64 ~/test (master)
$ git status
On branch master
Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        deleted:    second.txt

Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   first.txt


Administrator@NB16 MINGW64 ~/test (master)
$ git commit -m "fourth commit"
[master 3009455] fourth commit
 1 file changed, 1 deletion(-)
 delete mode 100644 second.txt

Administrator@NB16 MINGW64 ~/test (master)
$ ls -a
./  ../  .git/  first.txt


cat first.txt
test2
test3


git status
On branch master
Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)
        modified:   first.txt
no changes added to commit (use "git add" and/or "git commit -a")

git checkout first.txt

cat first.txt
test2

Administrator@NB16 MINGW64 ~/test (master)
$ echo "test4" >> first.txt

Administrator@NB16 MINGW64 ~/test (master)
$ git add .
warning: LF will be replaced by CRLF in first.txt.
The file will have its original line endings in your working directory.

Administrator@NB16 MINGW64 ~/test (master)
$ git status
On branch master
Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        modified:   first.txt


Administrator@NB16 MINGW64 ~/test (master)
$ cat first.txt
test2
test4

Administrator@NB16 MINGW64 ~/test (master)
$ git reset HEAD first.txt
Unstaged changes after reset:
M       first.txt

Administrator@NB16 MINGW64 ~/test (master)
$ cat first.txt
test2
test4

Administrator@NB16 MINGW64 ~/test (master)
$ git status
On branch master
Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   first.txt

no changes added to commit (use "git add" and/or "git commit -a")


```
# Markdown Syntax
## Phrase Emphasis ##

	*italic*   **bold**
	_italic_   __bold__


## Links ##

Inline:

	An [example](http://url.com/ "Title")

Reference-style labels (titles are optional):

	An [example][id]. Then, anywhere
	else in the doc, define the link:
	
	  [id]: http://example.com/  "Title"


## Images ##

Inline (titles are optional):

	![alt text](/path/img.jpg "Title")

Reference-style:

	![alt text][id]

	[id]: /url/to/img.jpg "Title"


## Headers ##

Setext-style:

	Header 1
	========
	
	Header 2
	--------

atx-style (closing #'s are optional):

	# Header 1 #

	## Header 2 ##

	###### Header 6


## Lists ##

Ordered, without paragraphs:

	1.  Foo
	2.  Bar

Unordered, with paragraphs:

	*   A list item.
	
		With multiple paragraphs.

	*   Bar

You can nest them:

	*   Abacus
		* answer
	*   Bubbles
		1.  bunk
		2.  bupkis
			* BELITTLER
		3. burper
	*   Cunning


## Blockquotes ##

	> Email-style angle brackets
	> are used for blockquotes.
	
	> > And, they can be nested.

	> #### Headers in blockquotes
	> 
	> * You can quote a list.
	> * Etc.


## Code Spans ##

	`<code>` spans are delimited
	by backticks.

	You can include literal backticks
	like `` `this` ``.


## Preformatted Code Blocks ##

Indent every line of a code block by at least 4 spaces or 1 tab.

	This is a normal paragraph.

	    This is a preformatted
	    code block.


## Horizontal Rules ##

Three or more dashes or asterisks:

	---
	
	* * *
	
	- - - - 


## Manual Line Breaks ##

End a line with two or more spaces:

	Roses are red,   
	Violets are blue.
 