import java.util.Scanner;

public class ChristmasTree {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());

        for (int row = 0; row < n + 1; row++) {
            String spaces = reapetsStr(" ", n -row);
            String stars = reapetsStr("*",row + n - n);
            System.out.println(spaces + stars + " | " + stars + spaces);

        }


    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}