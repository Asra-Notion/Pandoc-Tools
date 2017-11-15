package Pandoc.Native;

import Pandoc.Display;
import Pandoc.Input;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Operations {
    private static String currentWorkingFolder;
    private static String inputFormat;
    private static String outputFolder;
    private static String outputFormat;
    private static ArrayList<String> files = new ArrayList<String>();

    public static void parseArguments(String[] args) {
        String input = null;
        String outputLoc = null;
        String outputType = null;
        for (int i = 0; i < args.length; i++) {
            if (args[i].equals("-i")) {
                i++;
                input = args[i];
            } else if (args[i].equals("-o")) {
                i++;
                outputLoc = args[i];
            } else if (args[i].equals("-f")) {
                i++;
                outputType = args[i];
            }
        }
        setInputFormatAndOutputFolder(input, outputLoc, outputType);
    }

    public static void setInputFormatAndOutputFolder(String inputType, String outputLocation, String outputType) {
        inputFormat = inputType;
        outputFolder = outputLocation;
        outputFormat = outputType;
        currentWorkingFolder = System.getProperty("user.dir");
    }

    public static boolean allParametersAreSet() {
        return (inputFormat != null && outputFolder != null && outputFormat != null);
    }

    public static boolean checkForPandoc() {
        try {
            String line;
            Process pandoc = new ProcessBuilder("pandoc", "-v").start();
            BufferedReader input = new BufferedReader(new InputStreamReader(pandoc.getInputStream()));
            while ((line = input.readLine()) != null) {
                System.out.println(line);
            }
            input.close();
            return true;
        } catch (IOException e) {
            e.printStackTrace();
        }
        return false;
    }

    public static void findFiles() {
        ArrayList<File> files = new ArrayList<File>();
        listf(currentWorkingFolder, files);
    }

    public static void listf(String directoryName, ArrayList<File> files) {
        File directory = new File(directoryName);

        // get all the files from a directory
        File[] fList = directory.listFiles();
        for (File file : fList) {
            if (file.isFile() && file.getName().endsWith(".docx")) {
                files.add(file);
            } else if (file.isDirectory()) {
                listf(file.getAbsolutePath(), files);
            }
        }
    }

    public static void displaySelections() {
        if (inputFormat == null){
            Display.displayMenu();
            Input.getMenuSelection(1,3);
        }
        if (outputFolder == null) {
            Display.outputFolderSelection();
            Input.getOutputFolder();
        }
        if (outputFormat == null) {
            Display.displayOutputSelection();
            Input.getMenuSelection(1,4);
        }
    }
}
