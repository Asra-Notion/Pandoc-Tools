package Pandoc.Native;

import Pandoc.Display;
import Pandoc.Input;
import Pandoc.Types.FilePath;

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
    private static ArrayList<FilePath> filePaths = new ArrayList<FilePath>();
    private static ArrayList<ArrayList<String>> commands = new ArrayList<ArrayList<String>>();

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
        listFilesWithExtension(currentWorkingFolder, files);
        extractFilePaths(files, filePaths, inputFormat);
        if (filePaths.isEmpty()) {
            Display.errorNoFilesFound();
        }
    }

    private static void extractFilePaths(ArrayList<File> files, ArrayList<FilePath> paths, String format) {
        for (File f : files) {
            FilePath path = new FilePath(f.getPath(), format);
            paths.add(path);
        }
    }

    public static void listFilesWithExtension(String directoryName, ArrayList<File> files) {
        File directory = new File(directoryName);

        // get all the files from a directory
        File[] fList = directory.listFiles();
        for (File file : fList) {
            if (file.isFile() && file.getName().endsWith(inputFormat)) {
                files.add(file);
            } else if (file.isDirectory()) {
                listFilesWithExtension(file.getAbsolutePath(), files);
            }
        }
    }

    public static void displaySelections() {
        int selection;
        if (inputFormat == null) {
            Display.displayMenu();
            selection = Input.getMenuSelection(1, 3);
            setInputFormat(selection);
        }
        if (outputFolder == null) {
            Display.outputFolderSelection();
            outputFolder = Input.getOutputFolder();
        }
        if (outputFormat == null) {
            Display.displayOutputSelection();
            selection = Input.getMenuSelection(1, 4);
            setOutputFormat(selection);
        }
    }

    private static void setInputFormat(int selection) {
        switch (selection) {
            case 1:
                inputFormat = ".md";
                break;
            case 2:
                inputFormat = ".docx";
                break;
            case 3:
                inputFormat = ".pdf";
            default:
                break;
        }
    }

    private static void setOutputFormat(int selection) {
        switch (selection) {
            case 1:
                outputFormat = ".md";
                break;
            case 2:
                outputFormat = ".docx";
                break;
            case 3:
                outputFormat = ".pdf";
                break;
            case 4:
                outputFormat = ".html";
            default:
                break;
        }
    }

    private static void executeCommand() {
        try {
            for (ArrayList<String> item : commands) {
                Process pandoc = new ProcessBuilder(item).start();
                String line;
                BufferedReader output = new BufferedReader(new InputStreamReader(pandoc.getErrorStream()));
                while ((line = output.readLine()) != null) {
                    System.out.println(line);
                }
                output.close();
            }
        } catch (IOException e) {

        }
    }

    /*
    private static ArrayList<String> createCommand() {
        ArrayList<String> command = new ArrayList<String>();
        command.add("pandoc");
        command.add("-s");
        command.add(inputPath);
        command = addArgsToCommand(command);
        command.add("-o");
        command.add(outputPath);
        return command;
    }
    */

    public static void convertFiles() {
        buildCommands();
        executeCommand();
    }

    public static void buildCommands() {
        for (FilePath path : filePaths) {
            FilePath outputFile = new FilePath(path);
            outputFile.changeFileExtension(outputFormat);
            outputFile.modifyFilePathRelative(outputFolder, currentWorkingFolder);
            createOutput(outputFile);
            ArrayList<String> command = createCommand(path.provideCompletePath(), outputFile.provideCompletePath());
            commands.add(command);
        }
    }

    private static ArrayList<String> createCommand(String inputPath, String outputPath) {
        ArrayList<String> command = new ArrayList<String>();
        command.add("pandoc");
        command.add("-s");
        command.add(inputPath);
        //command = addArgsToCommand(command);
        command.add("-o");
        command.add(outputPath);
        return command;
    }

    private static void createOutput(FilePath outputFile) {
        String folder = outputFile.getFolder();
        File file = new File(folder);
        if (!file.exists()){
            file.mkdirs();
        }
    }
}
