import java.util.Scanner;

public class ChristmasHat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        String end = "";

        String fisrtRow = reapetsStr(".", 2 * n - 1)
                + "/|\\" + reapetsStr(".", 2 * n - 1);
        System.out.println(fisrtRow);

        String secondRow = reapetsStr(".", 2 * n - 1)
                + "\\|/" + reapetsStr(".", 2 * n - 1);
        System.out.println(secondRow);

        for (int i = 0; i < 2 * n; i++) {

            String middle = reapetsStr(".", (2 * n - 1) - i)
                    + "*" + reapetsStr("-", i) + "*"
                    + reapetsStr("-", i) + "*"
                    + reapetsStr(".", (2 * n - 1) - i);
            System.out.println(middle);
        }

        for (int i = 0; i < 3; i++) {
            if (i == 1){
                end = reapetsStr("*.", ((4 * n) + 1) / 2) + "*";
            }else{
                end = reapetsStr("*", (4 * n) + 1);
            }
            System.out.println(end);

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
