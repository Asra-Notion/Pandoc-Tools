package Pandoc.Types;


public class FilePath {
    private String extension;
    private String filenameAndPath;

    public FilePath(String completePath, String type){
        int index = completePath.indexOf(type);
        filenameAndPath = completePath.substring(0,index);
        extension = completePath.substring(index);
    }

    public FilePath(FilePath tester) {
        this.extension = tester.extension;
        this.filenameAndPath = tester.filenameAndPath;
    }

    public String getExtension() {
        return extension;
    }

    public String getFilenameAndPath() {
        return filenameAndPath;
    }

    public void changeFileExtension(String newExtension){
        this.extension = newExtension;
    }

    public String provideCompletePath(){
        String tmp = filenameAndPath + extension;
        return tmp;
    }
}
