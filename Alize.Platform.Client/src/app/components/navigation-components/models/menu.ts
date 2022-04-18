export interface IMenu {
    name: string;
    menuName: string;
    isSelected: boolean;
    isVisible: boolean;
    route: string;
    icon: string;
    breadcrumb: string;
    subMenu: IMenu[];
}