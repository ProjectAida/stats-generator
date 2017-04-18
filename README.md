Created by Yi Liu for Image Analysis for Archival Discovery.

## Installation ##

1. Windows
	- If you are using windows 7 or higher version of the Windows, there is no additional requirement for running this program.
	- Otherwise, you need to install .Net Framework 2.0

2. Mac or Linux
	- Install mono on your computer.
	- Use "mono [application name]" to run this program.



## Run Program ##

This program is a console program, which means it has to run in terminal (for Linux or Mac) or Command (for Windows)  
1. Change your current directory to the location of the .exe file with either Terminal or Command  
3. Use the following command to run this program
	- For Windows, "1836_1840CaseStudy.exe [full path of file A] [full path of file B] [saving path for result]";
	- For Mac or Linux, "mono 1836_1840CaseStudy.exe [full path of file A] [full path of file B] [saving path for result]";

### Detail explaination for three parameters ###

1. [full path of file A] is the full path for classifier results file, such as:
	- For Windows, "G:/MyWorkspace/AidaVSProject/1836-1840 case study/aida-temp/classifier-pages-false.txt"
	- For Mac or Linux, "/home/ian/workspace/classifier-pages-false.txt"
	*** the string of path better be qouted by "", otherwise, the space or symbol in this string could cause problems.

2. [full path of file B] is the full path for ground truth results file, such as:
	- For Windows, "G:/MyWorkspace/AidaVSProject/1836-1840 case study/aida-temp/ground-truth-pages-false.txt"
	- For Mac or Linux, "/home/ian/workspace/ground-truth-pages-false.txt"
	*** the string of path better be qouted by "", otherwise, the space or symbol in this string could cause problems.

3. [saving path for result] is the storage path for generated comparison .csv file. such as:
	- For Windows, "G:/MyWorkspace/AidaVSProject/1836-1840 case study/aida-temp/"
	- For Mac or Linux, "/home/ian/workspace/"
	*** the string of path better be qouted by "", otherwise, the space or symbol in this string could cause problems.

### other important notices ###

1. The strings in each lines of the classifier results file and the strings in each lines of the ground truth result file have to be comparable. For example:

In 1836-1840 case study, formation of strings in "classifier-pages-false.txt" is like "sn83016942_1839-03-14_ed-1_seq-4", while the formation of strings in "ground-truth-pages-false.txt" is like "sn83016942_1839-03-14_ed-1_seq-4_false.jpg". To make sure these two files are comparable, the "\_false.jpg" in "ground-truth-pages-false.txt" has to be deleted.

2. There are three part in generated .csv file.
	- The first part is the matched lines, and they will be labeled as 1;
	- The second part is the mismatchd lines, and they will be labeled as 0;
	- The third part is the lines contained in ground truth but not in classifier results, and they won't be labeled.

3. Before running: Make sure both files to be compared is not ocupied by other program, and make sure there is no file called "comparison result.csv" in target storage path.
