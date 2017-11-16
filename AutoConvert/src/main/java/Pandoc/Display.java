package Pandoc;

import Pandoc.Native.Operations;

public class Display {

    public static void displayWelcome() {
        System.out.println("Welcome to Pandoc-Tools AutoConvert");
    }

    public static void displayMenu() {
        System.out.println("Select an input format:");
        System.out.println("1. .md");
        System.out.println("2. .docx");
        System.out.println("3. .pdf");
    }

    public static void checkPandocPresent() {
        if (!Operations.checkForPandoc()) {
            System.out.println("Pandoc not found in the path value. Please install pandoc to use this tool.");
            try {
                Thread.sleep(5000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            System.exit(1);
        }
    }

    public static void outputFolderSelection() {
        System.out.println("Enter an output location (Full path to folder):");
    }

    public static void displayOutputSelection() {
        System.out.println("Select an output format:");
        System.out.println("1. .md");
        System.out.println("2. .docx");
        System.out.println("3. .pdf");
        System.out.println("4. .html");
    }

    public static void errorNoFilesFound() {
        System.out.println("Error, no files found of specified type. Exitting.");
        try {
            Thread.sleep(5000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.exit(1);
    }

    public static void convertingFileFromTo(String s, String s1) {
        System.out.println("Converting file :" + s);
        System.out.println("To :" + s1);
    }
}
