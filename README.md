## Contents ##
* Introduction
* Installation & Set-Up
* Running the program
  - Basic commands
  - Detailed explanation of three parameters Directories and Files
* Notes

## Introduction ##
This program compares two files, one with ground truth determinations made by a person and one with classifications derived from our software, to determine precision and accuracy of the system. This program was created by Yi Liu (@IanDing-Yi) of the University of Nebraska-Lincoln for Image Analysis for Archival Discovery. It is written in C#.NET 2.0.

## Installation & Set-Up ##

### Installation ###
1. Windows
	- If you are using windows 7 or higher version of the Windows, there is no additional requirement for running this program.
	- Otherwise, you need to install .Net Framework 2.0

2. Mac or Linux
	- Install mono on your computer.
	- Use `mono [application name]` to run this program.

### Set-Up ###
Running the program requires .txt files for comparison, e.g. "classifier-pages-false.txt" to be compared with "ground-truth-pages-false.txt," or "classifier-pages-true.txt" to be compared with "ground-truth-pages-true.txt."

## Running the Program ##

### Basic commands (new solution)###
1. This program is a console program, which means it has to run in terminal (for Linux or Mac) or Command (for Windows);

2. First step, change your current directory to the location of the .exe file with terminal or command;

3. Second, change the classifier result files' name into: (1)classifier-snippets-true.txt, (2)classifier-snippets-false.txt, (3)classifier-pages-true.txt, and (4)classifier-pages-false.txt.

4. Third, change the groundtruth files's name into: (1)ground-truth-snippets-true.txt, (2)ground-truth-snippets-false.txt, (3)ground-truth-pages-true.txt, and (4)ground-truth-pages-false.txt.

3. Fourth, use the following command to run this program
	- For Windows, "StatsGenerator.exe [SourceFileDirectory] [TargetStorageDirectory]";
	- For Mac or Linux, "mono StatsGenerator.exe [SourceFileDirectory] [TargetStorageDirectory]";

### Detailed explanation of three parameters (new solution)###
1. [SourceFileDirectory]
	This is the path of the files location for comparison.

2. [TargetStorageDirectory]
	This is the path of the output folder.

### Basic commands (old solution)###
This program is a console program, which means it has to run in terminal (for Linux or Mac) or Command (for Windows)  
1. Change your current directory to the location of the .exe file with either Terminal or Command  
3. Use the following command to run this program
	- For Windows: `StatsGenerator.exe [full path of file A] [full path of file B] [saving path for result file]`
	- For Mac or Linux: `mono StatsGenerator.exe [full path of file A] [full path of file B] [saving path for result file]`

### Detailed explanation of three parameters (old solution)###

* [full path of file A] is the full path for a classifier results file, such as:
	- Windows example: `G:/MyWorkspace/AidaVSProject/1836-1840 case study/aida-temp/classifier-pages-false.txt`
	- Mac or Linux example: `/home/ian/workspace/classifier-pages-false.txt`

* [full path of file B] is the full path for a ground truth file, such as:
	- Windows example: `G:/MyWorkspace/AidaVSProject/1836-1840 case study/aida-temp/ground-truth-pages-false.txt`
	- Mac or Linux example: `/home/ian/workspace/ground-truth-pages-false.txt`

* [saving path for result] is the storage path for generated comparison .csv file, such as:
	- Windows example: `G:/MyWorkspace/AidaVSProject/1836-1840 case study/aida-temp/`
	- Mac or Linux example `/home/ian/workspace/`

* For all parameters, the string of path better can be be quoted by "" if there are spaces or non alphanumeric characters in the path.

## Notes ##

1. The old solution is still functional. If you want to use the old solution, please follow the old solution instruction.

2. New solution can only running under current file formation.

3. The strings in each line of the classifier results file and the strings in each lines of the ground truth result file must  be comparable. For example, if the formation of strings in "classifier-pages-false.txt" is like "sn83016942_1839-03-14_ed-1_seq-4," while the formation of strings in "ground-truth-pages-false.txt" is like "sn83016942_1839-03-14_ed-1_seq-4_false.jpg," then to make the two files comparable, the "\_false.jpg" in "ground-truth-pages-false.txt" has to be deleted.

4. (old solution)There are three parts in the generated .csv file.
	- The first part is the matched lines, and they will be labeled as 1;
	- The second part is the mismatched lines, and they will be labeled as 0;
	- The third part is the lines contained in ground truth but not in classifier results; they won't be labeled.

5. (old solution)Before running: Make sure both files to be compared are not being used by another program and make sure there is no file called "comparison result.csv" in the target storage path.
