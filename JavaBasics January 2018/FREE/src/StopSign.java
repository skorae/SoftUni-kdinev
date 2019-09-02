import java.util.Scanner;

public class StopSign {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        int dots = n;
        int dashes = (n * 2) - 1;

        for (int i = n + 1; i > 0; i--) {
            if (i == n + 1) {
                String firstRow = reapetsStr(".", n + 1) + reapetsStr("_", (n * 2) + 1)
                        + reapetsStr(".", n + 1);
                System.out.println(firstRow);
            } else {
                String middleOne = reapetsStr(".", dots) + "//"
                        + reapetsStr("_", dashes) + "\\\\" + reapetsStr(".", dots);
                dots -= 1;
                dashes += 2;
                System.out.println(middleOne);
            }
        }
        String stop = "//" + reapetsStr("_", Math.round(dashes - 5) / 2) + "STOP!"
                + reapetsStr("_", Math.round(dashes - 5) / 2) + "\\\\";
        System.out.println(stop);

        for (int i = 0; i < n; i++) {
            String lastOne = reapetsStr(".", dots) + "\\\\"
                    + reapetsStr("_", dashes) + "//" + reapetsStr(".", dots);
            dots += 1;
            dashes -= 2;
            System.out.println(lastOne);
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
