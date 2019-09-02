import java.util.Scanner;

public class Parallelepiped {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());

        String firsRow = "+" + reapetsStr("~", n - 2) + "+"
                + reapetsStr(".", (n * 2) + 1);
        System.out.println(firsRow);

        for (int i = 0; i < (n * 2) + 1; i++) {
            String firstHalf = "|" + reapetsStr(".", i)
                    + "\\" + reapetsStr("~", n - 2) + "\\"
                    + reapetsStr(".", (n * 2) - i);
            System.out.println(firstHalf);
        }
        for (int i = 0; i < (n * 2) + 1; i++) {
            String secondHalf = reapetsStr(".", i)
                    + "\\" + reapetsStr(".", (n * 2) - i)
                    + "|" + reapetsStr("~", n - 2) + "|";
            System.out.println(secondHalf);
        }
        String lastRow = reapetsStr(".", (n * 2) + 1)
                +"+" + reapetsStr("~", n - 2) + "+";
        System.out.println(lastRow);
    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}
