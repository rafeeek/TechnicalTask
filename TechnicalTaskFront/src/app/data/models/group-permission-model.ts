export interface GroupPermissionModel {
    id: number,
	groupId: number,
	pageId: number,
	canVeiw: boolean,
	canAdd: boolean,
	canEdit: boolean,
	canDelete: boolean
}
