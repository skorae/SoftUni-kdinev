import java.util.Scanner;

public class CharacterStats {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        String name = scanner.nextLine();
        int curHealth = Integer.parseInt(scanner.nextLine());
        int maxH = Integer.parseInt(scanner.nextLine());
        int curEnergy = Integer.parseInt(scanner.nextLine());
        int maxE = Integer.parseInt(scanner.nextLine());

        int hdiff = maxH - curHealth;
        int ediff = maxE - curEnergy;

        String firsline = "Name: " + name;

        String HP = "Health: |" + reapetsStr("|", curHealth )+ reapetsStr(".", hdiff) + "|";
        String EG = "Energy: |" + reapetsStr("|", curEnergy )+ reapetsStr(".", ediff) + "|";

        System.out.println(firsline);
        System.out.println(HP);
        System.out.println(EG);
    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}
